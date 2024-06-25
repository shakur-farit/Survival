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

		public WeaponStaticData WeaponStaticData { private set; get; }

		[Inject]
		public void Constructor(IRandomService randomizer, IStaticDataService staticDataService,
			IPersistentProgressService persistentProgressService)
		{
			_randomizer = randomizer;
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake() =>
			GetRandomWeaponStaticData();

		private void GetRandomWeaponStaticData()
		{
			while (WeaponStaticData == null)
			{
				WeaponType randomType = GetRandomWeaponType();

				Debug.Log(randomType);

				if (_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Contains(randomType))
					continue;

				WeaponStaticData = GetWeaponStaticDataByType(randomType);

				_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Add(randomType);
			}
		}

		WeaponType GetRandomWeaponType()
		{
			Array values = Enum.GetValues(typeof(WeaponType));
			return (WeaponType)values.GetValue(_randomizer.Next(0, values.Length));
		}

		WeaponStaticData GetWeaponStaticDataByType(WeaponType type)
		{
			return _staticDataService.WeaponsListStaticData.WeaponsList
				.FirstOrDefault(weapon => weapon.Type == type);
		}
	}
}