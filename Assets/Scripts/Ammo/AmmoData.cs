using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoData : MonoBehaviour
	{
		private IPersistentProgressService _persistentProgressService;
		private IAmmoDestroy _ammoDestroy;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IAmmoDestroy ammoDestroy)
		{
			_persistentProgressService = persistentProgressService;
			_ammoDestroy = ammoDestroy;
		}

		private void Start()
		{
			int liveTime = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Ammo.LiveTime;

			_ammoDestroy.DestroyWithDelay(liveTime, gameObject);
		}
	}
}