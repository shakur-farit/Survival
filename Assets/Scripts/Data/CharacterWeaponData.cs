using System;
using StaticData;

namespace Data
{
	[Serializable]
	public class CharacterWeaponData
	{
		public WeaponStaticData CurrentWeapon;
		public int CurrentAmmoDamage;
		public int CurrentAmmoDelay;
	}
}