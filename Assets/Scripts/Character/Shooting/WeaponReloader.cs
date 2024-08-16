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

		public bool IsReloading { get; private set; }

		private readonly IPersistentProgressService _persistentProgressService;

		public WeaponReloader(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		public async UniTask Reload()
		{
			CharacterWeaponData weaponData = _persistentProgressService.Progress.CharacterData.WeaponData;

			if (IsReloading)
				return;
			
			ReloadInProgress?.Invoke();

			IsReloading = true;

			await UniTask.Delay(weaponData.ReloadTime);

			weaponData.CurrentAmmoCount = weaponData.MagazineSize;

			WeaponReloaded?.Invoke();

			IsReloading = false;
		}
	}
}