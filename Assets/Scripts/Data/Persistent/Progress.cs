using System;
using System.IO;
using UnityEngine;

namespace Data.Persistent
{
	[Serializable]
	public class Progress
	{
		public CharacterPersistentData CharacterData = new();
		public LeaderboardData LeaderboardData = new();
	}
}