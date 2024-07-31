using System;
using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Hud.Factory;
using Infrastructure.Services.Input;
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
		private bool _isShoot;
		private bool _infinityAmmo;
		private bool _isReloading;
		private int _shootInterval;
		private int _ammoCount;

		private IFireInputService _fireInputSystem;
		private IAmmoFactory _ammoFactory;
		private IPersistentProgressService _persistentProgressService;
		private ISpecialEffectsFactory _sfxFactory;
		private IWeaponReloader _weaponReloader;
		private IBulletIconFactory _bulletIconFactory;

		public bool TargetDetected { get; set; }

		[Inject]
		public void Constructor(IFireInputService fireInputSystem, IAmmoFactory ammoFactory,
			IPersistentProgressService persistentProgressService, ISpecialEffectsFactory sfxFactory,
			IWeaponReloader weaponReloader, IBulletIconFactory bulletIconFactory)
		{
			_fireInputSystem = fireInputSystem;
			_ammoFactory = ammoFactory;
			_persistentProgressService = persistentProgressService;
			_sfxFactory = sfxFactory;
			_weaponReloader = weaponReloader;
			_bulletIconFactory = bulletIconFactory;
		}

		private void OnEnable() => 
			_weaponReloader.WeaponReloaded += UpdateAmmoCount;

		private void OnDisable() => 
			_weaponReloader.WeaponReloaded -= UpdateAmmoCount;

		private void Awake()
		{
			_fireInputSystem.RegisterFireInputAction();
			_shootInterval = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.ShotsInterval;
			_ammoCount = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.MagazineSize;
			_infinityAmmo = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.IsInfinityAmmo;
		}

		private void Update()
		{
			if (_fireInputSystem.IsFireButtonPressed)
				TryToShoot();
		}

		private async void TryToShoot()
		{
			if (TargetDetected == false || _isShoot || _isReloading)
				return;

			if (_ammoCount <= 0 && _infinityAmmo == false)
			{
				await ReloadWeapon();

				return;
			}

			_isShoot = true;

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
				await CreateAmmo();
				GameObject shootEffect = await CreateSpecialEffect();
				InitializeSpecialEffect(shootEffect, weaponStaticData.specialEffect);

				await UniTask.Delay(spawnInterval);
			}

			await UniTask.Delay(_shootInterval);

			if(_infinityAmmo)
				return;

			_ammoCount--;

			_bulletIconFactory.Destroy();
		}

		private async UniTask CreateAmmo() =>
			await _ammoFactory.Create(transform);

		private async UniTask<GameObject> CreateSpecialEffect() =>
			await _sfxFactory.CreateShootEffect(transform.position);

		private void InitializeSpecialEffect(GameObject shootEffect, SpecialEffectStaticData staticData)
		{
			if (shootEffect.TryGetComponent(out SpecialEffectData data))
				data.Initialize(staticData);

			if (shootEffect.TryGetComponent(out SpecialEffectView view))
				view.Initialize(staticData);
		}

		private async UniTask ReloadWeapon()
		{
			_isReloading = true;

			await _weaponReloader.Reload();

			_isReloading = false;
		}

		private void UpdateAmmoCount() => 
			_ammoCount = _weaponReloader.AmmoCount;
	}
}