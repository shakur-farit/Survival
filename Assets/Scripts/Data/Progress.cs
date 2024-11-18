using System;
using StaticData;
using UnityEngine.Serialization;

namespace Data
{
	[Serializable]
	public class Progress
	{
		public CharacterData CharacterData = new();
		public EnemyData EnemyData = new();
		public LevelData LevelData = new();
		public ShopData ShopData = new();
		[FormerlySerializedAs("ScoreData")] public ScoreData CoinData = new();
		public SoundData SoundData = new();
	}
}