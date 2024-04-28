using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoDamage : MonoBehaviour
	{
		private int _damage;

		private PersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(PersistentProgressService persistentProgressService) =>
			_persistentProgressService = persistentProgressService;


		private void Start()
		{
			AmmoStaticData currentWeaponAmmo = _persistentProgressService.Progress.characterData.CurrentWeapon.Ammo;

			_damage = currentWeaponAmmo.Damage;
		}
	}
}