using System;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Shop
{
	public class ShopItemInitializer : MonoBehaviour
	{
		private IRandomService _randomizer;
		private IStaticDataService _staticDataService;

		public WeaponShopItemStaticData WeaponShopItemStaticData { private set; get; }

		[Inject]
		public void Constructor(IRandomService randomizer, IStaticDataService staticDataService)
		{
			_randomizer = randomizer;
			_staticDataService = staticDataService;
		}

		private void Awake()
		{
			GetRandomShopItemStaticData();
		}

		private void GetRandomShopItemStaticData()
		{
			Array values = Enum.GetValues(typeof(ShopItemType));
			ShopItemType randomShopItemType = ShopItemType.Weapon;
			//ShopItemType randomType = (ShopItemType)values.GetValue(_randomizer.Next(0, values.Length));

			//foreach (WeaponShopItemStaticData shopItemStatic in _staticDataService.ShopItemsListStaticData.ShopItemsList)
			//	if (randomShopItemType == shopItemStatic.Type)
			//		WeaponShopItemStaticData = shopItemStatic;
		}
	}
}