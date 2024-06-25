using System;
using StaticData;

namespace Data
{
	[Serializable]
	public class CharacterData
	{
		public CharacterStaticData CurrentCharacter;
		public WeaponStaticData CurrentWeapon;
		public int CurrentAmmoDamage;
		public int CurrentAmmoDelay;
	}
}