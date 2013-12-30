// This file is automatically generated!

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct FriendGameInfo_t {
		public CGameID m_gameID;
		public uint m_unGameIP;
		public ushort m_usGamePort;
		public ushort m_usQueryPort;
		public ulong m_steamIDLobby;
	}

	public struct FriendSessionStateInfo_t {
		public uint m_uiOnlineSessionInstances;
		public byte m_uiPublishedToFriendsSessionInstance;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct P2PSessionState_t {
		public byte m_bConnectionActive;
		public byte m_bConnecting;
		public byte m_eP2PSessionError;
		public byte m_bUsingRelay;
		public int m_nBytesQueuedForSend;
		public int m_nPacketsQueuedForSend;
		public uint m_nRemoteIP;
		public ushort m_nRemotePort;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct SteamParamStringArray_t {
		public IntPtr[] m_ppStrings;
		public int m_nNumStrings;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct SteamUGCDetails_t {
		public PublishedFileId_t m_nPublishedFileId;
		public EResult m_eResult;
		public EWorkshopFileType m_eFileType;
		public AppId_t m_nCreatorAppID;
		public AppId_t m_nConsumerAppID;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchPublishedDocumentTitleMax)]
		public string m_rgchTitle;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchPublishedDocumentDescriptionMax)]
		public string m_rgchDescription;
		public ulong m_ulSteamIDOwner;
		public uint m_rtimeCreated;
		public uint m_rtimeUpdated;
		public uint m_rtimeAddedToUserList;
		public ERemoteStoragePublishedFileVisibility m_eVisibility;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAcceptedForUse;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bTagsTruncated;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchTagListMax)]
		public string m_rgchTags;
		public UGCHandle_t m_hFile;
		public UGCHandle_t m_hPreviewFile;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchFilenameMax)]
		public string m_pchFileName;
		public int m_nFileSize;
		public int m_nPreviewFileSize;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchPublishedFileURLMax)]
		public string m_rgchURL;
		public uint m_unVotesUp;
		public uint m_unVotesDown;
		public float m_flScore;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct CallbackMsg_t {
		public int m_hSteamUser;
		public int m_iCallback;
		public IntPtr m_pubParam;
		public int m_cubParam;
	}

	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct LeaderboardEntry_t {
		public ulong m_steamIDUser;
		public int m_nGlobalRank;
		public int m_nScore;
		public int m_cDetails;
		public UGCHandle_t m_hUGC;
	}

	public struct MatchMakingKeyValuePair_t {
	}

	public struct SteamControllerState_t {
		public uint unPacketNum;
		public ulong ulButtons;
		public short sLeftPadX;
		public short sLeftPadY;
		public short sRightPadX;
		public short sRightPadY;
	}

}
