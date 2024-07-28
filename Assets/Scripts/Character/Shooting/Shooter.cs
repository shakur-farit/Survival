using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
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
		private int _shootInterval;
		private int _ammoCount;

		private IFireInputService _fireInputSystem;
		private IAmmoFactory _ammoFactory;
		private IStaticDataService _staticDataService;
		private IPersistentProgressService _persistentProgressService;
		private ISpecialEffectsFactory _sfxFactory;

		public bool TargetDetected { get; set; }

		[Inject]
		public void Constructor(IFireInputService fireInputSystem, IAmmoFactory ammoFactory,
			IPersistentProgressService persistentProgressService, ISpecialEffectsFactory sfxFactory)
		{
			_fireInputSystem = fireInputSystem;
			_ammoFactory = ammoFactory;
			_persistentProgressService = persistentProgressService;
			_sfxFactory = sfxFactory;
		}

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
			if (TargetDetected == false)
				return;

			if (_isShoot)
				return;

			if (_ammoCount <= 0 && _infinityAmmo == false)
				return;

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
			Debug.Log(_ammoCount);
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
	}
}