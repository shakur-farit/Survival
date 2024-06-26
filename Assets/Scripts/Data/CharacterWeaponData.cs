using System;
using StaticData;
using UnityEngine.Serialization;

namespace Data
{
	[Serializable]
	public class CharacterWeaponData
	{
		public WeaponStaticData CurrentWeapon;
		public int CurrentAmmoDamage;
		public int CurrentAmmoShootsInterval;
		public float Spread;
	}
}