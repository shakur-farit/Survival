using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using SpecialEffects;
using SpecialEffects.Factory;
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
		private ISpecialEffectsFactory _sfxFactory;

		[Inject]
		public void Constructor(IAmmoFactory ammoFactory, IPersistentProgressService persistentProgressService,
			ISpecialEffectsFactory sfxFactory)
		{
			_ammoFactory = ammoFactory;
			_sfxFactory = sfxFactory;
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
				GameObject shootEffect = await CreateSpecialEffect();
				InitializeSpecialEffect(shootEffect, weaponStaticData.specialEffect);

				await UniTask.Delay(spawnInterval);
			}

			await UniTask.Delay(_shootsInterval);
		}

		private async void CreateAmmo() => 
			await _ammoFactory.Create(transform);

		private async UniTask<GameObject> CreateSpecialEffect() => 
			await _sfxFactory.CreateShootEffect(transform.position);

		private void InitializeSpecialEffect(GameObject shootEffect, SpecialEffectStaticData staticData)
		{
			if (shootEffect.TryGetComponent(out SpecialEffectData data))
				data.Initialize(staticData);

			if(shootEffect.TryGetComponent(out SpecialEffectView view))
				view.Initialize(staticData);
		}
	}
}