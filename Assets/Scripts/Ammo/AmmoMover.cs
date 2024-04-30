using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoMover : MonoBehaviour
	{
		private float _movementSpeed;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void Start()
		{
			AmmoStaticData currentWeaponAmmo = _persistentProgressService.Progress.characterData.CurrentWeapon.Ammo;

			_movementSpeed = currentWeaponAmmo.MovementSpeed;
		}

		private void Update() => 
			transform.Translate(_movementSpeed, 0, 0);
	}
}