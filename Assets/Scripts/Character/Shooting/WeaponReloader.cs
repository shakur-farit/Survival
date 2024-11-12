using System;
using Cysharp.Threading.Tasks;
using Data;
using Effects.SoundEffects.Reload.Factory;
using Infrastructure.Services.PersistentProgress;

namespace Character.Shooting
{
	public class WeaponReloader : IWeaponReloader
	{
		public event Action ReloadInProgress;
		public event Action WeaponReloaded;

		public bool IsReloading { get; private set; }

		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IReloadSoundEffectFactory _soundEffect;

		public WeaponReloader(IPersistentProgressService persistentProgressService, IReloadSoundEffectFactory soundEffect)
		{
			_persistentProgressService = persistentProgressService;
			_soundEffect = soundEffect;
		}

		public async UniTask Reload()
		{
			CharacterWeaponData weaponData = _persistentProgressService.Progress.CharacterData.WeaponData;

			if (IsReloading)
				return;
			
			ReloadInProgress?.Invoke();

			IsReloading = true;

			_soundEffect.Create();

			await UniTask.Delay(weaponData.ReloadTime);

			weaponData.CurrentAmmoCount = weaponData.MagazineSize;

			WeaponReloaded?.Invoke();

			_soundEffect.Destroy();

			IsReloading = false;
		}
	}
}