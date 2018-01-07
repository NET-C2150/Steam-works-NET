// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2017 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// Changes to this file will be reverted when you update Steamworks.NET

#if !DISABLESTEAMWORKS

namespace Steamworks {
	[System.Serializable]
	public struct SteamInventoryUpdateHandle_t : System.IEquatable<SteamInventoryUpdateHandle_t>, System.IComparable<SteamInventoryUpdateHandle_t> {
		public static readonly SteamInventoryUpdateHandle_t Invalid = new SteamInventoryUpdateHandle_t(0xffffffffffffffff);
		public ulong m_SteamInventoryUpdateHandle;

		public SteamInventoryUpdateHandle_t(ulong value) {
			m_SteamInventoryUpdateHandle = value;
		}

		public override string ToString() {
			return m_SteamInventoryUpdateHandle.ToString();
		}

		public override bool Equals(object other) {
			return other is SteamInventoryUpdateHandle_t && this == (SteamInventoryUpdateHandle_t)other;
		}

		public override int GetHashCode() {
			return m_SteamInventoryUpdateHandle.GetHashCode();
		}

		public static bool operator ==(SteamInventoryUpdateHandle_t x, SteamInventoryUpdateHandle_t y) {
			return x.m_SteamInventoryUpdateHandle == y.m_SteamInventoryUpdateHandle;
		}

		public static bool operator !=(SteamInventoryUpdateHandle_t x, SteamInventoryUpdateHandle_t y) {
			return !(x == y);
		}

		public static explicit operator SteamInventoryUpdateHandle_t(ulong value) {
			return new SteamInventoryUpdateHandle_t(value);
		}

		public static explicit operator ulong(SteamInventoryUpdateHandle_t that) {
			return that.m_SteamInventoryUpdateHandle;
		}

		public bool Equals(SteamInventoryUpdateHandle_t other) {
			return m_SteamInventoryUpdateHandle == other.m_SteamInventoryUpdateHandle;
		}

		public int CompareTo(SteamInventoryUpdateHandle_t other) {
			return m_SteamInventoryUpdateHandle.CompareTo(other.m_SteamInventoryUpdateHandle);
		}
	}
}

#endif // !DISABLESTEAMWORKS
