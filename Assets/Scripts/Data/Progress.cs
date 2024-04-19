using System;

namespace Data
{
	[Serializable]
	public class Progress
	{
		public CharacterData characterData = new();
		public WeaponData weaponData = new();
	}
}