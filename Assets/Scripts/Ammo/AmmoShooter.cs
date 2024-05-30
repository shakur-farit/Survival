using System.Collections;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Factories.Ammo;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoShooter : MonoBehaviour
	{
		private float _delay;

		private IAmmoFactory _ammoFactory;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IAmmoFactory ammoFactory, IPersistentProgressService persistentProgressService)
		{
			_ammoFactory = ammoFactory;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake() => 
			_delay = _persistentProgressService.Progress.CharacterData.CurrentWeapon.Ammo.Dealy;

		private void Start() =>
			Shoot();

		private void Shoot() => 
			StartCoroutine(ShootRoutine());


		private IEnumerator ShootRoutine()
		{
			yield return new WaitForSeconds(_delay);
			CreateAmmo();
			StartCoroutine(ShootRoutine());
		}

		private async void CreateAmmo() =>
			await _ammoFactory.Create(transform);
	}
}