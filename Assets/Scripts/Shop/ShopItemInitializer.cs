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
		private WeaponStaticData _weaponStaticData;

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
			GetRandomWeaponStaticData();

		private void Start() => 
			InitializeShopItem();

		private void GetRandomWeaponStaticData()
		{
			while (_weaponStaticData == null)
			{
				Array values = Enum.GetValues(typeof(WeaponType));
				WeaponType randomType = (WeaponType)values.GetValue(_randomizer.Next(0, values.Length));

				if (_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Contains(randomType))
					continue;

				_weaponStaticData = _staticDataService.WeaponsListStaticData.WeaponsList
					.FirstOrDefault(weapon => weapon.Type == randomType);

				if (_weaponStaticData != null)
					_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Add(randomType);
			}
		}

		private void InitializeShopItem() => 
			_mediator.Initialize(_weaponStaticData);
	}
}