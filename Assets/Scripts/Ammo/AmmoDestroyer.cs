using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoDestroyer : MonoBehaviour
	{
		
		private bool _isDestroyed;

		private int _liveTime;

		private IAmmoFactory _ammoFactory;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IAmmoFactory ammoFactory, IPersistentProgressService persistentProgressService)
		{
			_ammoFactory = ammoFactory;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake() => 
			_liveTime = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Ammo.LiveTime;

		private async void Start() => 
			await DestroyAmmo();

		private void OnDestroy() => 
			_isDestroyed = true;

		private async UniTask DestroyAmmo()
		{
			await UniTask.Delay(_liveTime);

			if(_isDestroyed)
				return;

			_ammoFactory.Destroy(gameObject);
		}
	}
}