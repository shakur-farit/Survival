using Assets.Scripts.Infrastructure.Services.AssetsManagement;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Assets.Scripts.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ammo.Factory
{
	public class AmmoFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly PersistentProgressService _persistentProgressService;

		public GameObject Ammo { get; private set; }

		public AmmoFactory(AssetsProvider assetsProvider, PersistentProgressService persistentProgressService)
		{
			_assetsProvider = assetsProvider;
			_persistentProgressService = persistentProgressService;
		}

		public async UniTask WarmUp() => 
			await _assetsProvider.Load<GameObject>(AssetsAddresses.AmmoAddress);

		public async UniTask CreateAmmo(Transform parent)
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.AmmoAddress);
			Ammo = _assetsProvider.Instantiate(prefab, parent);

			Ammo.TryGetComponent(out AmmoMover ammo);

			AmmoStaticData currentWeaponAmmo = _persistentProgressService.Progress.characterData.CurrentWeapon.Ammo;

			ammo.Damage = currentWeaponAmmo.Damage;
			ammo.MovementSpeed = currentWeaponAmmo.MovementSpeed;
		}
	}
}