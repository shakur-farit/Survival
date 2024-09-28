using System;
using StaticData;

namespace Data
{
	[Serializable]
	public class LevelData
	{
		public int PreviousLevel;
		public LevelStaticData CurrentLevelStaticData;
		public int EnemiesNumberInLevele;
		public RoomData RoomData;
	}
}