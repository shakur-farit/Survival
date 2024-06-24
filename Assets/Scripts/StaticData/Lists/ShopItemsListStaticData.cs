using System.Collections.Generic;
using UnityEngine;

namespace StaticData.Lists
{
	[CreateAssetMenu(fileName = "Shop Items List", menuName = "Scriptable Object/Static Data/Shop Items List")]
	public class ShopItemsListStaticData : ScriptableObject
	{
		public List<WeaponShopItemStaticData> WeaponShopItemsList = new();
		public List<HealthShopItemStaticData> HealthShopItemsList = new();
	}
}