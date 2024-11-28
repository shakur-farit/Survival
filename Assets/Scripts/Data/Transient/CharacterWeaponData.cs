using System;
using StaticData;

namespace Data.Transient
{
	[Serializable]
	public class CharacterWeaponData
	{
		public WeaponStaticData CurrentWeapon;
		public float Range;
		public int Damage; 
		public int ShootsInterval;
		public int MagazineSize;
		public int ReloadTime;
		public float Spread;
		public int CurrentAmmoCount;
	}
}