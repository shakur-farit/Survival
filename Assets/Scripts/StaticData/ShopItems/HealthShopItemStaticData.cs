using UnityEngine;
using UnityEngine.Serialization;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Shop Item Static Data", menuName = "Scriptable Object/Static Data/Shop Item/Health")]
	public class HealthShopItemStaticData : ShopItemStaticData
	{
		public HealthShopItemType HealthItemType;
		public int HealthValue;
	}
}