using System;

namespace Data.Persistent
{
	[Serializable]
	public class Progress
	{
		public ScoreData ScoreData = new();
		public CharacterPersistentData CharacterData = new();
	}
}