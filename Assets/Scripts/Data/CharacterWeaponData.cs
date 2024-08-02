using System;
using StaticData;

namespace Data
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
	}
}