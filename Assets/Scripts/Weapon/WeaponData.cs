using System.Linq;
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

		private void Awake() => 
			SetupWeapon();

		private void SetupWeapon()
		{
			WeaponType currentWeaponType = _persistentProgressService.Progress.CharacterData.CurrentWeapon.Type;
			WeaponStaticData currentWeapon = _staticDataService.WeaponsListStaticData.WeaponsList
				.FirstOrDefault(weapon => weapon.Type == currentWeaponType);

			if (currentWeapon != null)
			{
				_persistentProgressService.Progress.CharacterData.CurrentWeapon = currentWeapon;
				_weaponShootPoint.position = currentWeapon.ShootPoint;
			}
		}
	}
}