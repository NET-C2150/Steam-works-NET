// This file is automatically generated!

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class SteamUGC {
		public static ulong CreateQueryUserUGCRequest(uint unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, uint nCreatorAppID, uint nConsumerAppID, uint unPage) {
			return NativeMethods.ISteamUGC_CreateQueryUserUGCRequest(unAccountID, eListType, eMatchingUGCType, eSortOrder, nCreatorAppID, nConsumerAppID, unPage);
		}

		public static ulong CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, uint nCreatorAppID, uint nConsumerAppID, uint unPage) {
			return NativeMethods.ISteamUGC_CreateQueryAllUGCRequest(eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, unPage);
		}

		public static ulong SendQueryUGCRequest(ulong handle) {
			return NativeMethods.ISteamUGC_SendQueryUGCRequest(handle);
		}

		public static bool GetQueryUGCResult(ulong handle, uint index, ref SteamUGCDetails_t pDetails) {
			return NativeMethods.ISteamUGC_GetQueryUGCResult(handle, index, ref pDetails);
		}

		public static bool ReleaseQueryUGCRequest(ulong handle) {
			return NativeMethods.ISteamUGC_ReleaseQueryUGCRequest(handle);
		}

		public static bool AddRequiredTag(ulong handle, string pTagName) {
			return NativeMethods.ISteamUGC_AddRequiredTag(handle, new InteropHelp.UTF8String(pTagName));
		}

		public static bool AddExcludedTag(ulong handle, string pTagName) {
			return NativeMethods.ISteamUGC_AddExcludedTag(handle, new InteropHelp.UTF8String(pTagName));
		}

		public static bool SetReturnLongDescription(ulong handle, bool bReturnLongDescription) {
			return NativeMethods.ISteamUGC_SetReturnLongDescription(handle, bReturnLongDescription);
		}

		public static bool SetReturnTotalOnly(ulong handle, bool bReturnTotalOnly) {
			return NativeMethods.ISteamUGC_SetReturnTotalOnly(handle, bReturnTotalOnly);
		}

		public static bool SetCloudFileNameFilter(ulong handle, string pMatchCloudFileName) {
			return NativeMethods.ISteamUGC_SetCloudFileNameFilter(handle, new InteropHelp.UTF8String(pMatchCloudFileName));
		}

		public static bool SetMatchAnyTag(ulong handle, bool bMatchAnyTag) {
			return NativeMethods.ISteamUGC_SetMatchAnyTag(handle, bMatchAnyTag);
		}

		public static bool SetSearchText(ulong handle, string pSearchText) {
			return NativeMethods.ISteamUGC_SetSearchText(handle, new InteropHelp.UTF8String(pSearchText));
		}

		public static bool SetRankedByTrendDays(ulong handle, uint unDays) {
			return NativeMethods.ISteamUGC_SetRankedByTrendDays(handle, unDays);
		}

		public static ulong RequestUGCDetails(PublishedFileId_t nPublishedFileID) {
			return NativeMethods.ISteamUGC_RequestUGCDetails(nPublishedFileID);
		}
	}
}