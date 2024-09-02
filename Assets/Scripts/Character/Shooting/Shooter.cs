using System;
using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Data;
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
		public Action Shot;

		[SerializeField] private Transform _weaponShootTransform;
		[SerializeField] private Transform _weaponRotationPoint;

		private bool _isShoot;
		private bool _infinityAmmo;
		private int _shootInterval;

		private IFireInputService _fireInputSystem;
		private IAmmoFactory _ammoFactory;
		private IPersistentProgressService _persistentProgressService;
		private ISpecialEffectsFactory _sfxFactory;
		private IWeaponReloader _weaponReloader;

		public bool TargetDetected { get; set; }

		[Inject]
		public void Constructor(IFireInputService fireInputSystem, IAmmoFactory ammoFactory,
			IPersistentProgressService persistentProgressService, ISpecialEffectsFactory sfxFactory,
			IWeaponReloader weaponReloader)
		{
			_fireInputSystem = fireInputSystem;
			_ammoFactory = ammoFactory;
			_persistentProgressService = persistentProgressService;
			_sfxFactory = sfxFactory;
			_weaponReloader = weaponReloader;
		}

		private void Awake()
		{
			_fireInputSystem.RegisterFireInputAction();

			CharacterWeaponData weaponData = _persistentProgressService.Progress.CharacterData.WeaponData;

			_shootInterval = weaponData.ShootsInterval;
			weaponData.CurrentAmmoCount = weaponData.MagazineSize;
			_infinityAmmo = weaponData.CurrentWeapon.IsInfinityAmmo;

		}

		private void Update()
		{
			if (_fireInputSystem.IsFireButtonPressed)
				TryToShoot();
		}

		private async void TryToShoot()
		{
			if (TargetDetected == false || _isShoot || _weaponReloader.IsReloading)
				return;

			if (_persistentProgressService.Progress.CharacterData.WeaponData.CurrentAmmoCount <= 0 && _infinityAmmo == false)
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
			CharacterWeaponData weaponData = _persistentProgressService.Progress.CharacterData.WeaponData;

			int ammoAmount = weaponData.CurrentWeapon.AmmoAmount;
			int spawnInterval = weaponData.CurrentWeapon.AmmoSpawnInterval;

			for (int i = 0; i < ammoAmount; i++)
			{
				await CreateAmmo();
				GameObject shootEffect = await CreateSpecialEffect();
				InitializeSpecialEffect(shootEffect, weaponData.CurrentWeapon.specialEffect);

				await UniTask.Delay(spawnInterval);
			}

			await UniTask.Delay(_shootInterval);

			if (_infinityAmmo)
				return;

			--weaponData.CurrentAmmoCount;
			Shot?.Invoke();
		}

		private async UniTask CreateAmmo() =>
			await _ammoFactory.Create(_weaponShootTransform.position, _weaponRotationPoint.rotation);

		private async UniTask<GameObject> CreateSpecialEffect() =>
			await _sfxFactory.CreateSpecialEffect(_weaponShootTransform.position);

		private void InitializeSpecialEffect(GameObject shootEffect, SpecialEffectStaticData staticData)
		{
			if (shootEffect.TryGetComponent(out SpecialEffectData data))
				data.Initialize(staticData);

			if (shootEffect.TryGetComponent(out SpecialEffectView view))
				view.Initialize(staticData);
		}

		private async UniTask ReloadWeapon() => 
			await _weaponReloader.Reload();
	}
}