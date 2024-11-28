using System.Linq;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.TransientGameData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Weapon
{
	public class WeaponData : MonoBehaviour
	{
		[SerializeField] private Transform _weaponShootPoint;

		private ITransientGameDataService _transientGameDataService;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService, IStaticDataService staticDataService)
		{
			_transientGameDataService = transientGameDataService;
			_staticDataService = staticDataService;
		}

		public void SetupWeapon()
		{
			WeaponType currentWeaponType = _transientGameDataService.Data.CharacterData.WeaponData.CurrentWeapon.Type;
			WeaponStaticData currentWeapon = _staticDataService.WeaponsListStaticData.WeaponsList
				.FirstOrDefault(weapon => weapon.Type == currentWeaponType);

			if (currentWeapon != null)
			{
				_transientGameDataService.Data.CharacterData.WeaponData.CurrentWeapon = currentWeapon;

				_weaponShootPoint.localPosition = currentWeapon.ShootPoint;
			}
		}
	}
}