using System;
using StaticData;

namespace Data.Transient
{
	[Serializable]
	public class CharacterData
	{
		public CharacterStaticData CurrentCharacter;
		public CharacterWeaponData WeaponData = new();

		public int CurrentHealth;
		public int MaxHealth;
		public int DamageTakingCooldown;
	}
}