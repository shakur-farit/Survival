using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using StaticData;

namespace Character.Shooting
{
	public class WeaponReloader : IWeaponReloader
	{
		public event Action ReloadInProgress;
		public event Action WeaponReloaded;

		private bool _isReloading;

		private readonly IPersistentProgressService _persistentProgressService;

		public WeaponReloader(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		public int AmmoCount { get; private set; }

		public async UniTask Reload()
		{
			WeaponStaticData currentWeapon = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon;

			ReloadInProgress?.Invoke();

			if (_isReloading)
				return;

			_isReloading = true;

			await UniTask.Delay(currentWeapon.ReloadTime);

			AmmoCount = currentWeapon.MagazineSize;

			WeaponReloaded?.Invoke();

			_isReloading = false;
		}
	}
}