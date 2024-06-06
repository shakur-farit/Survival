using System;

namespace Data
{
	[Serializable]
	public class Progress
	{
		public CharacterData CharacterData = new();
		public EnemyData EnemyData = new();
	}
}