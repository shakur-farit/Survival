using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Weapon
{
	public class WeaponData : MonoBehaviour
	{
		[SerializeField] private Transform _weaponShootPoint;

		private IPersistentProgressService _persistentProgressService;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IStaticDataService staticDataService)
		{
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		private void Awake()
		{
			foreach (WeaponStaticData weapon in _staticDataService.WeaponsListStaticData.WeaponsList)
			{
				if (weapon.Type == _persistentProgressService.Progress.CharacterData.CurrentWeapon.Type)
				{
					_persistentProgressService.Progress.CharacterData.CurrentWeapon = weapon;

					_weaponShootPoint.position = weapon.ShootPoint;
				}
			}
		}
	}
}