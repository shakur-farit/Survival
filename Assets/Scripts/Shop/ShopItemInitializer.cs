using System;
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
		private IRandomService _randomizer;
		private IStaticDataService _staticDataService;
		private IPersistentProgressService _persistentProgressService;
		private IShopMediator _mediator;

		[Inject]
		public void Constructor(IRandomService randomizer, IStaticDataService staticDataService,
			IPersistentProgressService persistentProgressService, IShopMediator mediator)
		{
			_randomizer = randomizer;
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
			_mediator = mediator;
		}

		private void Awake() => 
			InitializeShopItem(GetRandomWeaponStaticData());

		private WeaponStaticData GetRandomWeaponStaticData()
		{
			WeaponStaticData weaponStaticData = null;

			while (weaponStaticData == null)
			{
				Array values = Enum.GetValues(typeof(WeaponType));
				WeaponType randomType = (WeaponType)values.GetValue(_randomizer.Next(0, values.Length));

				if (_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Contains(randomType))
					continue;

				weaponStaticData = _staticDataService.WeaponsListStaticData.WeaponsList
					.FirstOrDefault(weapon => weapon.Type == randomType);

				if (weaponStaticData != null)
					_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Add(randomType);
			}

			return weaponStaticData;
		}

		private void InitializeShopItem(WeaponStaticData weaponStaticData)
		{
			Debug.Log(weaponStaticData.Type);
			_mediator.Initialize(weaponStaticData);
		}
	}
}