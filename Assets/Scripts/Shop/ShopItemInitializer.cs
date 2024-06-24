using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Weapon;
using Zenject;

namespace Shop
{
	public class ShopItemInitializer : MonoBehaviour
	{
		private Dictionary<ShopItemType, Action> _actionByItemType;

		private IRandomService _randomizer;
		private IStaticDataService _staticDataService;
		private IPersistentProgressService _persistentProgressService;

		public ShopItemType RandomShopItemType { get; private set; }

		public WeaponStaticData WeaponStaticData { get; private set; }
		public DropStaticData DropStaticData { get; private set; }

		[Inject]
		public void Constructor(IRandomService randomizer, IStaticDataService staticDataService,
			IPersistentProgressService persistentProgressService)
		{
			_randomizer = randomizer;
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake()
		{
			InitDictionary();

			GetRandomStaticData();
		}

		private void GetRandomStaticData()
		{
			Array values = Enum.GetValues(typeof(ShopItemType));
			RandomShopItemType = ShopItemType.Weapon;
			//ShopItemType randomType = (ShopItemType)values.GetValue(_randomizer.Next(0, values.Length));

			if (_actionByItemType.TryGetValue(RandomShopItemType, out Action action))
				action();
		}

		private void InitDictionary()
		{
			_actionByItemType = new Dictionary<ShopItemType, Action>
			{
				{ ShopItemType.Weapon, GetRandomWeaponStaticData },
			};
		}

		private void GetRandomWeaponStaticData()
		{
			while (WeaponStaticData == null)
			{
				Array values = Enum.GetValues(typeof(WeaponType));
				WeaponType randomType = (WeaponType)values.GetValue(_randomizer.Next(0, values.Length));

				if (_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Contains(randomType))
					continue;

				WeaponStaticData = _staticDataService.WeaponsListStaticData.WeaponsList
					.FirstOrDefault(weapon => weapon.Type == randomType);

				if (WeaponStaticData != null)
					_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Add(randomType);
			}

		}
	}
}