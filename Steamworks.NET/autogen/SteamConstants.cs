// This file is automatically generated!

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class Constants {
			public const int k_cubAppProofOfPurchaseKeyMax = 64;
			public const int k_iSteamUserCallbacks = 100;
			public const int k_iSteamGameServerCallbacks = 200;
			public const int k_iSteamFriendsCallbacks = 300;
			public const int k_iSteamBillingCallbacks = 400;
			public const int k_iSteamMatchmakingCallbacks = 500;
			public const int k_iSteamContentServerCallbacks = 600;
			public const int k_iSteamUtilsCallbacks = 700;
			public const int k_iClientFriendsCallbacks = 800;
			public const int k_iClientUserCallbacks = 900;
			public const int k_iSteamAppsCallbacks = 1000;
			public const int k_iSteamUserStatsCallbacks = 1100;
			public const int k_iSteamNetworkingCallbacks = 1200;
			public const int k_iClientRemoteStorageCallbacks = 1300;
			public const int k_iSteamUserItemsCallbacks = 1400;
			public const int k_iSteamGameServerItemsCallbacks = 1500;
			public const int k_iClientUtilsCallbacks = 1600;
			public const int k_iSteamGameCoordinatorCallbacks = 1700;
			public const int k_iSteamGameServerStatsCallbacks = 1800;
			public const int k_iSteam2AsyncCallbacks = 1900;
			public const int k_iSteamGameStatsCallbacks = 2000;
			public const int k_iClientHTTPCallbacks = 2100;
			public const int k_iClientScreenshotsCallbacks = 2200;
			public const int k_iSteamScreenshotsCallbacks = 2300;
			public const int k_iClientAudioCallbacks = 2400;
			public const int k_iClientUnifiedMessagesCallbacks = 2500;
			public const int k_iSteamStreamLauncherCallbacks = 2600;
			public const int k_iClientControllerCallbacks = 2700;
			public const int k_iSteamControllerCallbacks = 2800;
			public const int k_iClientParentalSettingsCallbacks = 2900;
			public const int k_iClientDeviceAuthCallbacks = 3000;
			public const int k_iClientNetworkDeviceManagerCallbacks = 3100;
			public const int k_iClientMusicCallbacks = 3200;
			public const int k_iClientRemoteClientManagerCallbacks = 3300;
			public const int k_iClientUGCCallbacks = 3400;
			public const int k_iSteamStreamClientCallbacks = 3500;
			public const int k_IClientProductBuilderCallbacks = 3600;
			public const int k_cchMaxFriendsGroupName = 64;
			public const int k_cFriendsGroupLimit = 100;
			public const int k_cEnumerateFollowersMax = 50;
			public const int k_cchPersonaNameMax = 128;
			public const int k_cwchPersonaNameMax = 32;
			public const int k_cubChatMetadataMax = 8192;
			public const int k_cchMaxRichPresenceKeys = 20;
			public const int k_cchMaxRichPresenceKeyLength = 64;
			public const int k_cchMaxRichPresenceValueLength = 256;
			public const int k_unServerFlagNone = 0x00;
			public const int k_unServerFlagActive = 0x01;
			public const int k_unServerFlagSecure = 0x02;
			public const int k_unServerFlagDedicated = 0x04;
			public const int k_unServerFlagLinux = 0x08;
			public const int k_unServerFlagPassworded = 0x10;
			public const int k_unServerFlagPrivate = 0x20;
			public const int HSERVERQUERY_INVALID = -1;
			public const int k_unFavoriteFlagNone = 0x00;
			public const int k_unFavoriteFlagFavorite = 0x01;
			public const int k_unFavoriteFlagHistory = 0x02;
			public const int k_unMaxCloudFileChunkSize = 100 * 1024 * 1024;
			public const ulong k_UGCHandleInvalid = 0xffffffffffffffff;
			public const ulong k_PublishedFileUpdateHandleInvalid = 0xffffffffffffffff;
			public const ulong k_UGCFileStreamHandleInvalid = 0xffffffffffffffff;
			public const int k_cchPublishedDocumentTitleMax = 128 + 1;
			public const int k_cchPublishedDocumentDescriptionMax = 8000;
			public const int k_cchPublishedDocumentChangeDescriptionMax = 8000;
			public const int k_unEnumeratePublishedFilesMaxResults = 50;
			public const int k_cchTagListMax = 1024 + 1;
			public const int k_cchFilenameMax = 260;
			public const int k_cchPublishedFileURLMax = 256;
			public const int k_WorkshopForceLoadPublishedFileDetailsFromCache = -1;
			public const int k_nScreenshotMaxTaggedUsers = 32;
			public const int k_nScreenshotMaxTaggedPublishedFiles = 32;
			public const int k_cubUFSTagTypeMax = 255;
			public const int k_cubUFSTagValueMax = 255;
			public const int k_ScreenshotThumbWidth = 200;
			public const ulong k_UGCQueryHandleInvalid = 0xffffffffffffffff;
			public const int kNumUGCResultsPerPage = 50;
			public const int k_cchStatNameMax = 128;
			public const int k_cchLeaderboardNameMax = 128;
			public const int k_cLeaderboardDetailsMax = 64;
			public const int k_cbMaxGameServerGameDir = 32;
			public const int k_cbMaxGameServerMapName = 32;
			public const int k_cbMaxGameServerGameDescription = 64;
			public const int k_cbMaxGameServerName = 64;
			public const int k_cbMaxGameServerTags = 128;
			public const int k_cbMaxGameServerGameData = 2048;
			public const uint k_HAuthTicketInvalid = 0;
			public const int k_unSteamAccountIDMask = -1;
			public const int k_unSteamAccountInstanceMask = 0x000FFFFF;
			public const int k_unSteamUserDesktopInstance = 1;
			public const int k_unSteamUserConsoleInstance = 2;
			public const int k_unSteamUserWebInstance = 4;
			public const int k_cchGameExtraInfoMax = 64;
			public const int k_cubSaltSize = 8;
			public const ulong k_GIDNil = 0xffffffffffffffff;
			public const ulong k_TxnIDNil = k_GIDNil;
			public const ulong k_TxnIDUnknown = 0;
			public const uint k_uPackageIdFreeSub = 0x0;
			public const uint k_uPackageIdInvalid = 0xFFFFFFFF;
			public const uint k_uAppIdInvalid = 0x0;
			public const ulong k_ulAssetClassIdInvalid = 0x0;
			public const uint k_uPhysicalItemIdInvalid = 0x0;
			public const uint k_uDepotIdInvalid = 0x0;
			public const uint k_uCellIDInvalid = 0xFFFFFFFF;
			public const ulong k_uAPICallInvalid = 0x0;
			public const uint k_uPartnerIdInvalid = 0;
	}
}
