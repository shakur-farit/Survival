using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factories.Ammo;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoShooter : MonoBehaviour
	{
		private int _delay;
		private bool _canShoot;

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

		public async void StartShoot()
		{
			_canShoot = true;

			while (_canShoot)
				await ShootRoutine();
		}

		public void StopShoot() => 
			_canShoot = false;

		private async UniTask ShootRoutine()
		{
			await UniTask.Delay(_delay);
			CreateAmmo();
		}

		private async void CreateAmmo() =>
			await _ammoFactory.Create(transform);
	}
}