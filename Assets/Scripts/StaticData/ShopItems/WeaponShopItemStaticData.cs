using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Shop Item Static Data", menuName = "Scriptable Object/Static Data/Shop Item/Weapon")]
	public class WeaponShopItemStaticData : ShopItemStaticData
	{
		public WeaponStaticData WeaponStaticData;
	}
}