using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

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
			ReloadInProgress?.Invoke();

			if (_isReloading)
				return;

			_isReloading = true;

			Debug.Log("Relaod begine");

			await UniTask.Delay(2000);

			AmmoCount = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.MagazineSize;
			Debug.Log("Relaod finished: ammo -" + AmmoCount);

			WeaponReloaded?.Invoke();

			_isReloading = false;
		}
	}
}