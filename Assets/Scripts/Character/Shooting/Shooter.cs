using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Character.Shooting
{
	public class Shooter : MonoBehaviour
	{
		private bool _isShoot;
		private int _shootCooldown;

		private IFireInputService _fireInputSystem;
		private IAmmoFactory _ammoFactory;
		private IStaticDataService _staticDataService;
		private IPersistentProgressService _persistentProgressService;

		public bool CanShoot { get; set; }

		[Inject]
		public void Constructor(IFireInputService fireInputSystem, IAmmoFactory ammoFactory, 
			IPersistentProgressService persistentProgressService)
		{
			_fireInputSystem = fireInputSystem;
			_ammoFactory = ammoFactory;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake()
		{
			_fireInputSystem.RegisterFireInputAction();
			_shootCooldown = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.ShotsInterval;
		}

		private void Update()
		{
			if (_fireInputSystem.IsFireButtonPressed)
				TryToShoot();
		}

		private async void TryToShoot()
		{
			if (CanShoot == false)
				return;

			if (_isShoot)
				return;

			_isShoot = true;


			await Shoot();

			_isShoot = false;
		}

		private async UniTask Shoot()
		{
			await CreateAmmo();
			await UniTask.Delay(_shootCooldown);
		}

		private async UniTask CreateAmmo() =>
			await _ammoFactory.Create(transform);
	}
}