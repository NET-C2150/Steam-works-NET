// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class SteamUtils {
		/// <summary>
		/// <para> return the number of seconds since the user</para>
		/// </summary>
		public static uint GetSecondsSinceAppActive() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSecondsSinceAppActive();
		}

		public static uint GetSecondsSinceComputerActive() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSecondsSinceComputerActive();
		}

		/// <summary>
		/// <para> the universe this client is connecting to</para>
		/// </summary>
		public static EUniverse GetConnectedUniverse() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetConnectedUniverse();
		}

		/// <summary>
		/// <para> Steam server time - in PST, number of seconds since January 1, 1970 (i.e unix time)</para>
		/// </summary>
		public static uint GetServerRealTime() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetServerRealTime();
		}

		/// <summary>
		/// <para> returns the 2 digit ISO 3166-1-alpha-2 format country code this client is running in (as looked up via an IP-to-location database)</para>
		/// <para> e.g "US" or "UK".</para>
		/// </summary>
		public static string GetIPCountry() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetIPCountry();
		}

		/// <summary>
		/// <para> returns true if the image exists, and valid sizes were filled out</para>
		/// </summary>
		public static bool GetImageSize(int iImage, out uint pnWidth, out uint pnHeight) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetImageSize(iImage, out pnWidth, out pnHeight);
		}

		/// <summary>
		/// <para> returns true if the image exists, and the buffer was successfully filled out</para>
		/// <para> results are returned in RGBA format</para>
		/// <para> the destination buffer size should be 4 * height * width * sizeof(char)</para>
		/// </summary>
		public static bool GetImageRGBA(int iImage, byte[] pubDest, int nDestBufferSize) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetImageRGBA(iImage, pubDest, nDestBufferSize);
		}

		/// <summary>
		/// <para> returns the IP of the reporting server for valve - currently only used in Source engine games</para>
		/// </summary>
		public static bool GetCSERIPPort(out uint unIP, out ushort usPort) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetCSERIPPort(out unIP, out usPort);
		}

		/// <summary>
		/// <para> return the amount of battery power left in the current system in % [0..100], 255 for being on AC power</para>
		/// </summary>
		public static byte GetCurrentBatteryPower() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetCurrentBatteryPower();
		}

		/// <summary>
		/// <para> returns the appID of the current process</para>
		/// </summary>
		public static AppId_t GetAppID() {
			InteropHelp.TestIfAvailableClient();
			return (AppId_t)NativeMethods.ISteamUtils_GetAppID();
		}

		/// <summary>
		/// <para> Sets the position where the overlay instance for the currently calling game should show notifications.</para>
		/// <para> This position is per-game and if this function is called from outside of a game context it will do nothing.</para>
		/// </summary>
		public static void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetOverlayNotificationPosition(eNotificationPosition);
		}

		/// <summary>
		/// <para> API asynchronous call results</para>
		/// <para> can be used directly, but more commonly used via the callback dispatch API (see steam_api.h)</para>
		/// </summary>
		public static bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsAPICallCompleted(hSteamAPICall, out pbFailed);
		}

		public static ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetAPICallFailureReason(hSteamAPICall);
		}

		public static bool GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetAPICallResult(hSteamAPICall, pCallback, cubCallback, iCallbackExpected, out pbFailed);
		}

		/// <summary>
		/// <para> this needs to be called every frame to process matchmaking results</para>
		/// <para> redundant if you're already calling SteamAPI_RunCallbacks()</para>
		/// </summary>
		public static void RunFrame() {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_RunFrame();
		}

		/// <summary>
		/// <para> returns the number of IPC calls made since the last time this function was called</para>
		/// <para> Used for perf debugging so you can understand how many IPC calls your game makes per frame</para>
		/// <para> Every IPC call is at minimum a thread context switch if not a process one so you want to rate</para>
		/// <para> control how often you do them.</para>
		/// </summary>
		public static uint GetIPCCallCount() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetIPCCallCount();
		}

		/// <summary>
		/// <para> API warning handling</para>
		/// <para> 'int' is the severity; 0 for msg, 1 for warning</para>
		/// <para> 'const char *' is the text of the message</para>
		/// <para> callbacks will occur directly after the API function is called that generated the warning or message</para>
		/// </summary>
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetWarningMessageHook(pFunction);
		}

		/// <summary>
		/// <para> Returns true if the overlay is running &amp; the user can access it. The overlay process could take a few seconds to</para>
		/// <para> start &amp; hook the game process, so this function will initially return false while the overlay is loading.</para>
		/// </summary>
		public static bool IsOverlayEnabled() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsOverlayEnabled();
		}

		/// <summary>
		/// <para> Normally this call is unneeded if your game has a constantly running frame loop that calls the</para>
		/// <para> D3D Present API, or OGL SwapBuffers API every frame.</para>
		/// <para> However, if you have a game that only refreshes the screen on an event driven basis then that can break</para>
		/// <para> the overlay, as it uses your Present/SwapBuffers calls to drive it's internal frame loop and it may also</para>
		/// <para> need to Present() to the screen any time an even needing a notification happens or when the overlay is</para>
		/// <para> brought up over the game by a user.  You can use this API to ask the overlay if it currently need a present</para>
		/// <para> in that case, and then you can check for this periodically (roughly 33hz is desirable) and make sure you</para>
		/// <para> refresh the screen with Present or SwapBuffers to allow the overlay to do it's work.</para>
		/// </summary>
		public static bool BOverlayNeedsPresent() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_BOverlayNeedsPresent();
		}
#if ! _PS3
		/// <summary>
		/// <para> Asynchronous call to check if an executable file has been signed using the public key set on the signing tab</para>
		/// <para> of the partner site, for example to refuse to load modified executable files.</para>
		/// <para> The result is returned in CheckFileSignature_t.</para>
		/// <para>   k_ECheckFileSignatureNoSignaturesFoundForThisApp - This app has not been configured on the signing tab of the partner site to enable this function.</para>
		/// <para>   k_ECheckFileSignatureNoSignaturesFoundForThisFile - This file is not listed on the signing tab for the partner site.</para>
		/// <para>   k_ECheckFileSignatureFileNotFound - The file does not exist on disk.</para>
		/// <para>   k_ECheckFileSignatureInvalidSignature - The file exists, and the signing tab has been set for this file, but the file is either not signed or the signature does not match.</para>
		/// <para>   k_ECheckFileSignatureValidSignature - The file is signed and the signature is valid.</para>
		/// </summary>
		public static SteamAPICall_t CheckFileSignature(string szFileName) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUtils_CheckFileSignature(szFileName);
		}
#endif
#if _PS3
		public static void PostPS3SysutilCallback(ulong status, ulong param, IntPtr userdata) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_PostPS3SysutilCallback(status, param, userdata);
		}

		public static bool BIsReadyToShutdown() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_BIsReadyToShutdown();
		}

		public static bool BIsPSNOnline() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_BIsPSNOnline();
		}

		/// <summary>
		/// <para> Call this with localized strings for the language the game is running in, otherwise default english</para>
		/// <para> strings will be used by Steam.</para>
		/// </summary>
		public static void SetPSNGameBootInviteStrings(string pchSubject, string pchBody) {
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetPSNGameBootInviteStrings(pchSubject, pchBody);
		}
#endif
		/// <summary>
		/// <para> Activates the Big Picture text input dialog which only supports gamepad input</para>
		/// </summary>
		public static bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_ShowGamepadTextInput(eInputMode, eLineInputMode, pchDescription, unCharMax, pchExistingText);
		}

		/// <summary>
		/// <para> Returns previously entered text &amp; length</para>
		/// </summary>
		public static uint GetEnteredGamepadTextLength() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetEnteredGamepadTextLength();
		}

		public static bool GetEnteredGamepadTextInput(out string pchText, uint cchText) {
			InteropHelp.TestIfAvailableClient();
			IntPtr pchText2 = Marshal.AllocHGlobal((int)cchText);
			bool ret = NativeMethods.ISteamUtils_GetEnteredGamepadTextInput(pchText2, cchText);
			pchText = ret ? InteropHelp.PtrToStringUTF8(pchText2) : null;
			Marshal.FreeHGlobal(pchText2);
			return ret;
		}

		/// <summary>
		/// <para> returns the language the steam client is running in, you probably want ISteamApps::GetCurrentGameLanguage instead, this is for very special usage cases</para>
		/// </summary>
		public static string GetSteamUILanguage() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSteamUILanguage();
		}

		/// <summary>
		/// <para> returns true if Steam itself is running in VR mode</para>
		/// </summary>
		public static bool IsSteamRunningInVR() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsSteamRunningInVR();
		}
	}
}