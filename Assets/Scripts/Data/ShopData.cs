using System;
using System.Collections.Generic;
using Shop;
using Weapon;

namespace Data
{
	[Serializable]
	public class ShopData
	{
		public List<WeaponType> UsedWeaponTypes = new();
		public List<WeaponUpgradeType> UsedWeaponUpgradeTypes = new();
	}
}