using Ammo.Factory;
using Cysharp.Threading.Tasks;
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

		[Inject]
		public void Constructor(IAmmoFactory ammoFactory, IPersistentProgressService persistentProgressService)
		{
			_ammoFactory = ammoFactory;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake() =>
			_delay = _persistentProgressService.Progress.CharacterData.CurrentWeapon.Ammo.Dealy;

		public async void TryToShoot()
		{
			if(_isShoot)
				return;

			_isShoot = true;

			while (_persistentProgressService.Progress.EnemyData.EnemiesInRangeList.Count > 0) 
				await Shoot();

			_isShoot = false;
		}

		private async UniTask Shoot()
		{
			CreateAmmo();
			await UniTask.Delay(_delay);
		}

		private async void CreateAmmo() => 
			await _ammoFactory.Create(transform);
	}
}