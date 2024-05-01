using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoDamage : MonoBehaviour
	{
		private int _damage;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) =>
			_persistentProgressService = persistentProgressService;


		private void Start()
		{
			AmmoStaticData currentWeaponAmmo = _persistentProgressService.Progress.CharacterData.CurrentWeapon.Ammo;

			_damage = currentWeaponAmmo.Damage;
		}
	}
}