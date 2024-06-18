using System;

namespace Data
{
	[Serializable]
	public class Progress
	{
		public CharacterData CharacterData = new();
		public EnemyData EnemyData = new();
		public LevelData LevelData = new();
		public DropData DropData = new();
	}
}