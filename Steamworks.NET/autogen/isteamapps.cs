// This file is automatically generated!

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class SteamApps {
		public static bool BIsSubscribed() {
			return NativeMethods.ISteamApps_BIsSubscribed();
		}

		public static bool BIsLowViolence() {
			return NativeMethods.ISteamApps_BIsLowViolence();
		}

		public static bool BIsCybercafe() {
			return NativeMethods.ISteamApps_BIsCybercafe();
		}

		public static bool BIsVACBanned() {
			return NativeMethods.ISteamApps_BIsVACBanned();
		}

		public static string GetCurrentGameLanguage() {
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetCurrentGameLanguage());
		}

		public static string GetAvailableGameLanguages() {
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetAvailableGameLanguages());
		}

		public static bool BIsSubscribedApp(uint appID) {
			return NativeMethods.ISteamApps_BIsSubscribedApp(appID);
		}

		public static bool BIsDlcInstalled(uint appID) {
			return NativeMethods.ISteamApps_BIsDlcInstalled(appID);
		}

		public static uint GetEarliestPurchaseUnixTime(uint nAppID) {
			return NativeMethods.ISteamApps_GetEarliestPurchaseUnixTime(nAppID);
		}

		public static bool BIsSubscribedFromFreeWeekend() {
			return NativeMethods.ISteamApps_BIsSubscribedFromFreeWeekend();
		}

		public static int GetDLCCount() {
			return NativeMethods.ISteamApps_GetDLCCount();
		}

		public static bool BGetDLCDataByIndex(int iDLC, out uint pAppID, out bool pbAvailable, out string pchName, int cchNameBufferSize) {
			IntPtr pchName2 = Marshal.AllocHGlobal(cchNameBufferSize);
			bool ret = NativeMethods.ISteamApps_BGetDLCDataByIndex(iDLC, out pAppID, out pbAvailable, pchName2, cchNameBufferSize);
			pchName = InteropHelp.PtrToStringUTF8(pchName2);
			Marshal.FreeHGlobal(pchName2);
			return ret;
		}

		public static void InstallDLC(uint nAppID) {
			NativeMethods.ISteamApps_InstallDLC(nAppID);
		}

		public static void UninstallDLC(uint nAppID) {
			NativeMethods.ISteamApps_UninstallDLC(nAppID);
		}

		public static void RequestAppProofOfPurchaseKey(uint nAppID) {
			NativeMethods.ISteamApps_RequestAppProofOfPurchaseKey(nAppID);
		}

		public static bool GetCurrentBetaName(out string pchName, int cchNameBufferSize) {
			IntPtr pchName2 = Marshal.AllocHGlobal(cchNameBufferSize);
			bool ret = NativeMethods.ISteamApps_GetCurrentBetaName(pchName2, cchNameBufferSize);
			pchName = InteropHelp.PtrToStringUTF8(pchName2);
			Marshal.FreeHGlobal(pchName2);
			return ret;
		}

		public static bool MarkContentCorrupt(bool bMissingFilesOnly) {
			return NativeMethods.ISteamApps_MarkContentCorrupt(bMissingFilesOnly);
		}

		public static uint GetInstalledDepots(uint appID, IntPtr pvecDepots, uint cMaxDepots) {
			return NativeMethods.ISteamApps_GetInstalledDepots(appID, pvecDepots, cMaxDepots);
		}

		public static uint GetAppInstallDir(uint appID, out string pchFolder, uint cchFolderBufferSize) {
			IntPtr pchFolder2 = Marshal.AllocHGlobal((int)cchFolderBufferSize);
			uint ret = NativeMethods.ISteamApps_GetAppInstallDir(appID, pchFolder2, cchFolderBufferSize);
			pchFolder = InteropHelp.PtrToStringUTF8(pchFolder2);
			Marshal.FreeHGlobal(pchFolder2);
			return ret;
		}

		public static bool BIsAppInstalled(uint appID) {
			return NativeMethods.ISteamApps_BIsAppInstalled(appID);
		}

		public static ulong GetAppOwner() {
			return NativeMethods.ISteamApps_GetAppOwner();
		}

		public static string GetLaunchQueryParam(string pchKey) {
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetLaunchQueryParam(new InteropHelp.UTF8String(pchKey)));
		}
#if _PS3
		public static ulong RegisterActivationCode(string pchActivationCode) {
			return NativeMethods.ISteamApps_RegisterActivationCode(new InteropHelp.UTF8String(pchActivationCode));
		}
#endif
	}
}