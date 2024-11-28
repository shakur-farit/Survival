using System;
using Cysharp.Threading.Tasks;
using Data;
using Data.Transient;
using Effects.SoundEffects.Reload.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;

namespace Character.Shooting
{
	public class WeaponReloader : IWeaponReloader
	{
		public event Action ReloadInProgress;
		public event Action WeaponReloaded;

		public bool IsReloading { get; private set; }

		private readonly ITransientGameDataService _transientGameDataService;
		private readonly IReloadSoundEffectFactory _soundEffect;

		public WeaponReloader(ITransientGameDataService transientGameDataService, IReloadSoundEffectFactory soundEffect)
		{
			_transientGameDataService = transientGameDataService;
			_soundEffect = soundEffect;
		}

		public async UniTask Reload()
		{
			CharacterWeaponData weaponData = _transientGameDataService.Data.CharacterData.WeaponData;

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