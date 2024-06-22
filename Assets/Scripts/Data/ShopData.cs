using System;
using System.Collections.Generic;
using Weapon;

namespace Data
{
	[Serializable]
	public class ShopData
	{
		public List<WeaponType> UsedWeaponTypes = new();
	}
}