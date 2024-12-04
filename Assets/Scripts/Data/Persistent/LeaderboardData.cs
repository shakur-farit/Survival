using System;
using System.Collections.Generic;

namespace Data.Persistent
{
	[Serializable]
	public class LeaderboardData
	{
		public List<LeaderboardItemInfo> LeaderboardList = new();
	}

	[Serializable]
	public struct LeaderboardItemInfo
	{
		public string Name;
		public string Score;
	}
}