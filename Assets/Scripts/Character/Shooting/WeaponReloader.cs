using System;
using Cysharp.Threading.Tasks;
using Data;
using Infrastructure.Services.PersistentProgress;

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
			CharacterWeaponData weaponData = _persistentProgressService.Progress.CharacterData.WeaponData;

			ReloadInProgress?.Invoke();

			if (_isReloading)
				return;

			_isReloading = true;

			await UniTask.Delay(weaponData.ReloadTime);

			AmmoCount = weaponData.MagazineSize;

			WeaponReloaded?.Invoke();

			_isReloading = false;
		}
	}
}