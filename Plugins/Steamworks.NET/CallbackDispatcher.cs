// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2019 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

#if UNITY_ANDROID || UNITY_IOS || UNITY_TIZEN || UNITY_TVOS || UNITY_WEBGL || UNITY_WSA || UNITY_PS4 || UNITY_WII || UNITY_XBOXONE || UNITY_SWITCH
#define DISABLESTEAMWORKS
#endif

#if !DISABLESTEAMWORKS

#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_5 || UNITY_4_6
	#error Unsupported Unity platform. Steamworks.NET requires Unity 4.7 or higher.
#elif UNITY_4_7 || UNITY_5 || UNITY_2017 || UNITY_2017_1_OR_NEWER
	#if UNITY_EDITOR_WIN || (UNITY_STANDALONE_WIN && !UNITY_EDITOR)
		#define WINDOWS_BUILD
	#endif
#elif STEAMWORKS_WIN
	#define WINDOWS_BUILD
#elif STEAMWORKS_LIN_OSX
	// So that we don't enter the else block below.
#else
	#error You need to define STEAMWORKS_WIN, or STEAMWORKS_LIN_OSX. Refer to the readme for more details.
#endif

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class CallbackDispatcher {
		// We catch exceptions inside callbacks and reroute them here.
		// For some reason throwing an exception causes RunCallbacks() to break otherwise.
		// If you have a custom ExceptionHandler in your engine you can register it here manually until we get something more elegant hooked up.
		public static void ExceptionHandler(Exception e) {
#if UNITY_STANDALONE
			UnityEngine.Debug.LogException(e);
#elif STEAMWORKS_WIN || STEAMWORKS_LIN_OSX
			Console.WriteLine(e.Message);
#endif
		}

		private static Dictionary<int, List<Callback>> m_registeredCallbacks = new Dictionary<int, List<Callback>>();
		private static Dictionary<int, List<Callback>> m_registeredGameServerCallbacks = new Dictionary<int, List<Callback>>();
		private static Dictionary<ulong, List<CallResult>> m_registeredCallResults = new Dictionary<ulong, List<CallResult>>();
		private static object m_sync = new object();
		private static IntPtr m_pCallbackMsg;
		private static int m_initCount;

		public static bool IsInitialized {
			get { return m_initCount > 0; }
		}

		internal static void Initialize() {
			lock (m_sync) {
				if (m_initCount == 0) {
					NativeMethods.SteamAPI_ManualDispatch_Init();
					m_pCallbackMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CallbackMsg_t)));
				}
				++m_initCount;
			}
		}

		internal static void Shutdown() {
			lock (m_sync) {
				--m_initCount;
				if (m_initCount == 0) {
					UnregisterAll();
					Marshal.FreeHGlobal(m_pCallbackMsg);
					m_pCallbackMsg = IntPtr.Zero;
				}
			}
		}

		internal static void Register(Callback cb) {
			int iCallback = CallbackIdentities.GetCallbackIdentity(cb.GetCallbackType());
			var callbacksRegistry = cb.IsGameServer ? m_registeredGameServerCallbacks : m_registeredCallbacks;
			lock (m_sync) {
				List<Callback> callbacksList;
				if (!callbacksRegistry.TryGetValue(iCallback, out callbacksList)) {
					callbacksList = new List<Callback>();
					callbacksRegistry.Add(iCallback, callbacksList);
				}

				callbacksList.Add(cb);
			}
		}

		internal static void Register(SteamAPICall_t asyncCall, CallResult cr) {
			lock (m_sync) {
				List<CallResult> callResultsList;
				if (!m_registeredCallResults.TryGetValue((ulong)asyncCall, out callResultsList)) {
					callResultsList = new List<CallResult>();
					m_registeredCallResults.Add((ulong)asyncCall, callResultsList);
				}

				callResultsList.Add(cr);
			}
		}

		internal static void Unregister(Callback cb) {
			int iCallback = CallbackIdentities.GetCallbackIdentity(cb.GetCallbackType());
			var callbacksRegistry = cb.IsGameServer ? m_registeredGameServerCallbacks : m_registeredCallbacks;
			lock (m_sync) {
				List<Callback> callbacksList;
				if (callbacksRegistry.TryGetValue(iCallback, out callbacksList)) {
					callbacksList.Remove(cb);
					if (callbacksList.Count == 0)
						callbacksRegistry.Remove(iCallback);
				}
			}
		}

		internal static void Unregister(SteamAPICall_t asyncCall, CallResult cr) {
			lock (m_sync) {
				List<CallResult> callResultsList;
				if (m_registeredCallResults.TryGetValue((ulong)asyncCall, out callResultsList)) {
					callResultsList.Remove(cr);
					if (callResultsList.Count == 0)
						m_registeredCallResults.Remove((ulong)asyncCall);
				}
			}
		}

		private static void UnregisterAll() {
			List<Callback> callbacks = new List<Callback>();
			List<CallResult> callResults = new List<CallResult>();
			lock (m_sync) {
				foreach (var pair in m_registeredCallbacks) {
					callbacks.AddRange(pair.Value);
				}
				m_registeredCallbacks.Clear();

				foreach (var pair in m_registeredGameServerCallbacks) {
					callbacks.AddRange(pair.Value);
				}
				m_registeredGameServerCallbacks.Clear();

				foreach (var pair in m_registeredCallResults) {
					callResults.AddRange(pair.Value);
				}
				m_registeredCallResults.Clear();

				foreach (var callback in callbacks) {
					callback.SetUnregistered();
				}

				foreach (var callResult in callResults) {
					callResult.SetUnregistered();
				}
			}
		}

		internal static void RunFrame(bool isGameServer) {
			if (!IsInitialized) throw new InvalidOperationException("Callback dispatcher is not initialized.");

			HSteamPipe hSteamPipe = (HSteamPipe)(isGameServer ? NativeMethods.SteamGameServer_GetHSteamPipe() : NativeMethods.SteamAPI_GetHSteamPipe());
			NativeMethods.SteamAPI_ManualDispatch_RunFrame(hSteamPipe);
			var callbacksRegistry = isGameServer ? m_registeredGameServerCallbacks : m_registeredCallbacks;
			while (NativeMethods.SteamAPI_ManualDispatch_GetNextCallback(hSteamPipe, m_pCallbackMsg)) {
				CallbackMsg_t callbackMsg = (CallbackMsg_t)Marshal.PtrToStructure(m_pCallbackMsg, typeof(CallbackMsg_t));
				try {
					// Check for dispatching API call results
					if (callbackMsg.m_iCallback == SteamAPICallCompleted_t.k_iCallback) {
						SteamAPICallCompleted_t callCompletedCb = (SteamAPICallCompleted_t)Marshal.PtrToStructure(callbackMsg.m_pubParam, typeof(SteamAPICallCompleted_t));
						IntPtr pTmpCallResult = Marshal.AllocHGlobal((int)callCompletedCb.m_cubParam);
						bool bFailed;
						if (NativeMethods.SteamAPI_ManualDispatch_GetAPICallResult(hSteamPipe, callCompletedCb.m_hAsyncCall, pTmpCallResult, (int)callCompletedCb.m_cubParam, callCompletedCb.m_iCallback, out bFailed)) {
							lock (m_sync) {
								List<CallResult> callResults;
								if (m_registeredCallResults.TryGetValue((ulong)callCompletedCb.m_hAsyncCall, out callResults)) {
									m_registeredCallResults.Remove((ulong)callCompletedCb.m_hAsyncCall);
									foreach (var cr in callResults) {
										cr.OnRunCallResult(pTmpCallResult, bFailed, (ulong)callCompletedCb.m_hAsyncCall);
										cr.SetUnregistered();
									}
								}
							}
						}
						Marshal.FreeHGlobal(pTmpCallResult);
					} else {
						List<Callback> callbacks;
						if (callbacksRegistry.TryGetValue(callbackMsg.m_iCallback, out callbacks)) {
							List<Callback> callbacksCopy;
							lock (m_sync) {
								callbacksCopy = new List<Callback>(callbacks);
							}
							foreach (var callback in callbacksCopy) {
								callback.OnRunCallback(callbackMsg.m_pubParam);
							}
						}
					}
				} catch (Exception e) {
					ExceptionHandler(e);
				} finally {
					NativeMethods.SteamAPI_ManualDispatch_FreeLastCallback(hSteamPipe);
				}
			}
		}
	}

	public abstract class Callback {
		public abstract bool IsGameServer { get; }
		internal abstract Type GetCallbackType();
		internal abstract void OnRunCallback(IntPtr pvParam);
		internal abstract void SetUnregistered();
	}

	public sealed class Callback<T> : Callback, IDisposable {
		public delegate void DispatchDelegate(T param);
		private event DispatchDelegate m_Func;

		private bool m_bGameServer;
		private bool m_bIsRegistered;

		private bool m_bDisposed = false;

		/// <summary>
		/// Creates a new Callback. You must be calling SteamAPI.RunCallbacks() to retrieve the callbacks.
		/// <para>Returns a handle to the Callback.</para>
		/// <para>This MUST be assigned to a member variable to prevent the GC from cleaning it up.</para>
		/// </summary>
		public static Callback<T> Create(DispatchDelegate func) {
			return new Callback<T>(func, bGameServer: false);
		}

		/// <summary>
		/// Creates a new GameServer Callback. You must be calling GameServer.RunCallbacks() to retrieve the callbacks.
		/// <para>Returns a handle to the Callback.</para>
		/// <para>This MUST be assigned to a member variable to prevent the GC from cleaning it up.</para>
		/// </summary>
		public static Callback<T> CreateGameServer(DispatchDelegate func) {
			return new Callback<T>(func, bGameServer: true);
		}

		public Callback(DispatchDelegate func, bool bGameServer = false) {
			m_bGameServer = bGameServer;
			Register(func);
		}

		~Callback() {
			Dispose();
		}

		public void Dispose() {
			if (m_bDisposed) {
				return;
			}

			GC.SuppressFinalize(this);

			if (m_bIsRegistered)
				Unregister();

			m_bDisposed = true;
		}

		// Manual registration of the callback
		public void Register(DispatchDelegate func) {
			if (func == null) {
				throw new Exception("Callback function must not be null.");
			}

			if (m_bIsRegistered) {
				Unregister();
			}

			m_Func = func;

			CallbackDispatcher.Register(this);
			m_bIsRegistered = true;
		}

		public void Unregister() {
			CallbackDispatcher.Unregister(this);
			m_bIsRegistered = false;
		}

		public override bool IsGameServer {
			get { return m_bGameServer; }
		}

		internal override Type GetCallbackType() {
			return typeof(T);
		}

		internal override void OnRunCallback(IntPtr pvParam) {
			try {
				m_Func((T)Marshal.PtrToStructure(pvParam, typeof(T)));
			}
			catch (Exception e) {
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		internal override void SetUnregistered() {
			m_bIsRegistered = false;
		}
	}

	public abstract class CallResult {
		internal abstract Type GetCallbackType();
		internal abstract void OnRunCallResult(IntPtr pvParam, bool bFailed, ulong hSteamAPICall);
		internal abstract void SetUnregistered();
	}

	public sealed class CallResult<T> : CallResult, IDisposable {
		public delegate void APIDispatchDelegate(T param, bool bIOFailure);
		private event APIDispatchDelegate m_Func;

		private SteamAPICall_t m_hAPICall = SteamAPICall_t.Invalid;
		public SteamAPICall_t Handle { get { return m_hAPICall; } }

		private bool m_bDisposed = false;

		/// <summary>
		/// Creates a new async CallResult. You must be calling SteamAPI.RunCallbacks() to retrieve the callback.
		/// <para>Returns a handle to the CallResult.</para>
		/// <para>This MUST be assigned to a member variable to prevent the GC from cleaning it up.</para>
		/// </summary>
		public static CallResult<T> Create(APIDispatchDelegate func = null) {
			return new CallResult<T>(func);
		}

		public CallResult(APIDispatchDelegate func = null) {
			m_Func = func;
		}

		~CallResult() {
			Dispose();
		}

		public void Dispose() {
			if (m_bDisposed) {
				return;
			}

			GC.SuppressFinalize(this);

			Cancel();

			m_bDisposed = true;
		}

		public void Set(SteamAPICall_t hAPICall, APIDispatchDelegate func = null) {
			// Unlike the official SDK we let the user assign a single function during creation,
			// and allow them to skip having to do so every time that they call .Set()
			if (func != null) {
				m_Func = func;
			}

			if (m_Func == null) {
				throw new Exception("CallResult function was null, you must either set it in the CallResult Constructor or via Set()");
			}

			if (m_hAPICall != SteamAPICall_t.Invalid) {
				CallbackDispatcher.Unregister(m_hAPICall, this);
			}

			m_hAPICall = hAPICall;

			if (hAPICall != SteamAPICall_t.Invalid) {
				CallbackDispatcher.Register(hAPICall, this);
			}
		}

		public bool IsActive() {
			return (m_hAPICall != SteamAPICall_t.Invalid);
		}

		public void Cancel() {
			if (IsActive())
				CallbackDispatcher.Unregister(m_hAPICall, this);
		}

		internal override Type GetCallbackType() {
			return typeof(T);
		}

		internal override void OnRunCallResult(IntPtr pvParam, bool bFailed, ulong hSteamAPICall_) {
			SteamAPICall_t hSteamAPICall = (SteamAPICall_t)hSteamAPICall_;
			if (hSteamAPICall == m_hAPICall) {
				try {
					m_Func((T)Marshal.PtrToStructure(pvParam, typeof(T)), bFailed);
				}
				catch (Exception e) {
					CallbackDispatcher.ExceptionHandler(e);
				}
			}
		}

		internal override void SetUnregistered() {
			m_hAPICall = SteamAPICall_t.Invalid;
		}
	}
}

#endif // !DISABLESTEAMWORKS
