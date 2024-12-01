using System;

namespace Data.Transient
{
	[Serializable]
	public class TransientGameData
	{
		public CharacterTransientData CharacterData = new();
		public EnemyData EnemyData = new();
		public LevelData LevelData = new();
		public ShopData ShopData = new();
		public CoinData CoinData = new();
		public SoundData SoundData = new();
	}
}