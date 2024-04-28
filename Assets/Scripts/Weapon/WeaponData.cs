using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Weapon
{
	public class WeaponData : MonoBehaviour
	{
		public Transform WeaponShootPoint;

		private PersistentProgressService _persistentProgressService;
		private StaticDataService _staticDataService;

		[Inject]
		public void Constructor(PersistentProgressService persistentProgressService, StaticDataService staticDataService)
		{
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		private void Start()
		{
			foreach (WeaponStaticData weapon in _staticDataService.WeaponsList)
			{
				if (weapon.Type == _persistentProgressService.Progress.characterData.CurrentCharacterStaticData.DefaultWeapon)
				{
					_persistentProgressService.Progress.characterData.CurrentWeapon = weapon;

					WeaponShootPoint.position = weapon.ShootPoint;
				}
			}
		}
	}
}