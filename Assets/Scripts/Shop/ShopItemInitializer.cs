using System;
using System.Linq;
using Data;
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

		public WeaponStaticData WeaponStaticData
		{
			get
			{
				if (_weaponStaticData == null)
					return _weaponStaticData = GetRandomWeaponStaticData();

				return _weaponStaticData;
			}
		}

		public WeaponUpgradeType WeaponUpgradeType { get; private set; }

		[Inject]
		public void Constructor(IRandomService randomizer, IStaticDataService staticDataService,
			IPersistentProgressService persistentProgressService)
		{
			_randomizer = randomizer;
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		private void OnDisable() =>
			_weaponStaticData = null;

		private WeaponStaticData GetRandomWeaponStaticData()
		{
			WeaponStaticData weaponStaticData = null;
			ShopData shopData = _persistentProgressService.Progress.ShopData;

			while (weaponStaticData == null)
			{
				WeaponType randomWeaponType = GetRandomWeaponType();
				WeaponUpgradeType randomUpgradeType = GetRandomUpgradeType();

				if(randomWeaponType == _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Type && 
				   randomUpgradeType == WeaponUpgradeType.None)
					continue;

				if(shopData.UsedWeaponTypes.Contains(randomWeaponType) && 
				    shopData.UsedWeaponUpgradeTypes.Contains(randomUpgradeType))
					continue;

				weaponStaticData = GetWeaponStaticDataByType(randomWeaponType);
				WeaponUpgradeType = randomUpgradeType;

				shopData.UsedWeaponTypes.Add(randomWeaponType);
				shopData.UsedWeaponUpgradeTypes.Add(randomUpgradeType);
			}

			return weaponStaticData;
		}

		private WeaponType GetRandomWeaponType()
		{
			Array values = Enum.GetValues(typeof(WeaponType));
			return (WeaponType)values.GetValue(_randomizer.Next(0, values.Length));
		}

		private WeaponUpgradeType GetRandomUpgradeType()
		{
			Array values = Enum.GetValues(typeof(WeaponUpgradeType));
			return (WeaponUpgradeType)values.GetValue(_randomizer.Next(0, values.Length));
		}

		private WeaponStaticData GetWeaponStaticDataByType(WeaponType type)
		{
			return _staticDataService.WeaponsListStaticData.WeaponsList
				.FirstOrDefault(weapon => weapon.Type == type);
		}
	}
}