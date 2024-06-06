using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factories.Ammo;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character.Shooting
{
	public class Shooter : MonoBehaviour
	{
		private int _delay;

		private IAmmoFactory _ammoFactory;
		private IPersistentProgressService _persistentProgressService;
		private bool _isShoot;
		private bool _canShoot;

		[Inject]
		public void Constructor(IAmmoFactory ammoFactory, IPersistentProgressService persistentProgressService)
		{
			_ammoFactory = ammoFactory;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake() =>
			_delay = _persistentProgressService.Progress.CharacterData.CurrentWeapon.Ammo.Dealy;

		private async void TryToShoot()
		{
			if(_isShoot)
				return;

			if (_persistentProgressService.Progress.EnemyData.EnemiesInRangeList.Count > 0) 
				_canShoot = true;

			while (_canShoot) 
				await Shoot();
		}

		private async UniTask Shoot()
		{
			await UniTask.Delay(_delay);
			CreateAmmo();
		}

		private async void CreateAmmo() =>
			await _ammoFactory.Create(transform);
	}
}