using System;
using StaticData;

namespace Data
{
	[Serializable]
	public class Progress
	{
		public CharacterData CharacterData = new();
		public EnemyData EnemyData = new();
		public LevelData LevelData = new();
		public ShopData ShopData = new();
		public ScoreData ScoreData = new();
		public SoundData SoundData = new();
	}
}