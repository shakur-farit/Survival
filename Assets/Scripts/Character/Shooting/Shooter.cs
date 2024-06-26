using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Character.Shooting
{
	public class Shooter : MonoBehaviour
	{
		private int _shootsInterval;

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
			_shootsInterval = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentAmmoShootsInterval;

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
			WeaponStaticData weaponStaticData = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon;

			int ammoAmount = weaponStaticData.AmmoAmount;
			int spawnInterval = weaponStaticData.AmmoSpawnInterval;

			for (int i = 0; i < ammoAmount; i++)
			{
				CreateAmmo();
				await UniTask.Delay(spawnInterval);
			}

			await UniTask.Delay(_shootsInterval);
		}

		private async void CreateAmmo() => 
			await _ammoFactory.Create(transform);
	}
}