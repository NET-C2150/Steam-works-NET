// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2014 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	// friend game played information
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct FriendGameInfo_t {
		public CGameID m_gameID;
		public uint m_unGameIP;
		public ushort m_usGamePort;
		public ushort m_usQueryPort;
		public CSteamID m_steamIDLobby;
	}

	//-----------------------------------------------------------------------------
	// Purpose: information about user sessions
	//-----------------------------------------------------------------------------
	public struct FriendSessionStateInfo_t {
		public uint m_uiOnlineSessionInstances;
		public byte m_uiPublishedToFriendsSessionInstance;
	}

	// connection state to a specified user, returned by GetP2PSessionState()
	// this is under-the-hood info about what's going on with a SendP2PPacket(), shouldn't be needed except for debuggin
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct P2PSessionState_t {
		public byte m_bConnectionActive;		// true if we've got an active open connection
		public byte m_bConnecting;			// true if we're currently trying to establish a connection
		public byte m_eP2PSessionError;		// last error recorded (see enum above)
		public byte m_bUsingRelay;			// true if it's going through a relay server (TURN)
		public int m_nBytesQueuedForSend;
		public int m_nPacketsQueuedForSend;
		public uint m_nRemoteIP;				// potential IP:Port of remote host. Could be TURN server.
		public ushort m_nRemotePort;			// Only exists for compatibility with older authentication api's
	}

	//-----------------------------------------------------------------------------
	// Purpose: Structure that contains an array of const char * strings and the number of those strings
	//-----------------------------------------------------------------------------
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct SteamParamStringArray_t {
		public IntPtr m_ppStrings;
		public int m_nNumStrings;
	}

	// Details for a single published file/UGC
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct SteamUGCDetails_t {
		public PublishedFileId_t m_nPublishedFileId;
		public EResult m_eResult;												// The result of the operation.
		public EWorkshopFileType m_eFileType;									// Type of the file
		public AppId_t m_nCreatorAppID;										// ID of the app that created this file.
		public AppId_t m_nConsumerAppID;										// ID of the app that will consume this file.
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchPublishedDocumentTitleMax)]
		public string m_rgchTitle;				// title of document
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchPublishedDocumentDescriptionMax)]
		public string m_rgchDescription;	// description of document
		public ulong m_ulSteamIDOwner;										// Steam ID of the user who created this content.
		public uint m_rtimeCreated;											// time when the published file was created
		public uint m_rtimeUpdated;											// time when the published file was last updated
		public uint m_rtimeAddedToUserList;									// time when the user added the published file to their list (not always applicable)
		public ERemoteStoragePublishedFileVisibility m_eVisibility;			// visibility
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;													// whether the file was banned
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAcceptedForUse;											// developer has specifically flagged this item as accepted in the Workshop
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bTagsTruncated;											// whether the list of tags was too long to be returned in the provided buffer
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchTagListMax)]
		public string m_rgchTags;								// comma separated list of all tags associated with this file
		// file/url information
		public UGCHandle_t m_hFile;											// The handle of the primary file
		public UGCHandle_t m_hPreviewFile;										// The handle of the preview file
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchFilenameMax)]
		public string m_pchFileName;							// The cloud filename of the primary file
		public int m_nFileSize;												// Size of the primary file
		public int m_nPreviewFileSize;										// Size of the preview file
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.k_cchPublishedFileURLMax)]
		public string m_rgchURL;						// URL (for a video or a website)
		// voting information
		public uint m_unVotesUp;												// number of votes up
		public uint m_unVotesDown;											// number of votes down
		public float m_flScore;												// calculated score
		public uint m_unNumChildren;											// if m_eFileType == k_EWorkshopFileTypeCollection, then this number will be the number of children contained within the collection
	}

	// structure that contains client callback data
	// see callbacks documentation for more details
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct CallbackMsg_t {
		public int m_hSteamUser;
		public int m_iCallback;
		public IntPtr m_pubParam;
		public int m_cubParam;
	}

	// a single entry in a leaderboard, as returned by GetDownloadedLeaderboardEntry()
	[StructLayout(LayoutKind.Sequential, Pack = Packsize.value)]
	public struct LeaderboardEntry_t {
		public CSteamID m_steamIDUser; // user with the entry - use SteamFriends()->GetFriendPersonaName() & SteamFriends()->GetFriendAvatar() to get more info
		public int m_nGlobalRank;	// [1..N], where N is the number of users with an entry in the leaderboard
		public int m_nScore;			// score as set in the leaderboard
		public int m_cDetails;		// number of int32 details available for this entry
		public UGCHandle_t m_hUGC;		// handle for UGC attached to the entry
	}

	/// Store key/value pair used in matchmaking queries.
	///
	/// Actually, the name Key/Value is a bit misleading.  The "key" is better
	/// understood as "filter operation code" and the "value" is the operand to this
	/// filter operation.  The meaning of the operand depends upon the filter.
	[StructLayout(LayoutKind.Sequential)]
	public struct MatchMakingKeyValuePair_t {
		MatchMakingKeyValuePair_t(string strKey, string strValue) {
			m_szKey = strKey;
			m_szValue = strValue;
		}
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szKey;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szValue;
	}

	// Only add fields to the end of this struct, or if you need to change it in a larger
	// way add a new message id and new struct completely so as to not break old clients.
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SteamControllerState_t {
		// If packet num matches that on your prior call, then the controller state hasn't been changed since
		// your last call and there is no need to process it
		public uint unPacketNum;
		
		// bit flags for each of the buttons
		public ulong ulButtons;
		
		// Left pad coordinates
		public short sLeftPadX;
		public short sLeftPadY;
		
		// Right pad coordinates
		public short sRightPadX;
		public short sRightPadY;
		
	}

}
