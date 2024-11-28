using System;
using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Data;
using Data.Transient;
using Effects.SoundEffects.Shot.Factory;
using Effects.SpecialEffects.Shot.Factory;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
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
		private ITransientGameDataService _transientGameDataService;
		private IShootSpecialEffectsFactory _sfxFactory;
		private IWeaponReloader _weaponReloader;
		private IShotSoundEffectFactory _shotSoundEffect;

		public bool TargetDetected { get; set; }

		[Inject]
		public void Constructor(IFireInputService fireInputSystem, IAmmoFactory ammoFactory,
			ITransientGameDataService transientGameDataService, IShootSpecialEffectsFactory sfxFactory,
			IWeaponReloader weaponReloader, IShotSoundEffectFactory shotSoundEffect)
		{
			_fireInputSystem = fireInputSystem;
			_ammoFactory = ammoFactory;
			_transientGameDataService = transientGameDataService;
			_sfxFactory = sfxFactory;
			_weaponReloader = weaponReloader;
			_shotSoundEffect = shotSoundEffect;
		}

		private void OnEnable()
		{
			_fireInputSystem.RegisterFireInputAction();

			CharacterWeaponData weaponData = _transientGameDataService.Data.CharacterData.WeaponData;

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
			if ( _isShoot || _weaponReloader.IsReloading)
				return;

			if (_transientGameDataService.Data.CharacterData.WeaponData.CurrentAmmoCount <= 0 && _infinityAmmo == false)
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
			CharacterWeaponData weaponData = _transientGameDataService.Data.CharacterData.WeaponData;

			int ammoAmount = weaponData.CurrentWeapon.AmmoAmount;
			int spawnInterval = weaponData.CurrentWeapon.AmmoSpawnInterval;

			for (int i = 0; i < ammoAmount; i++)
			{
				CreateAmmo();
				CreateSpecialEffect();
				CreateSoundEffect();

				await UniTask.Delay(spawnInterval);
			}

			await UniTask.Delay(_shootInterval);

			if (_infinityAmmo)
				return;

			--weaponData.CurrentAmmoCount;
			Shot?.Invoke();
		}

		private void CreateAmmo() => 
			_ammoFactory.Create(_weaponShootTransform.position, _weaponRotationPoint.rotation);

		private void CreateSpecialEffect() =>
			_sfxFactory.Create(_weaponShootTransform.position);

		private void CreateSoundEffect() => 
			_shotSoundEffect.Create();

		private async UniTask ReloadWeapon() => 
			await _weaponReloader.Reload();
	}
}