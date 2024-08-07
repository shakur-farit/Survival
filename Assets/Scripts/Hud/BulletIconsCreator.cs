using System.Diagnostics.Contracts;
using Character.Shooting;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Utility;
using Zenject;

namespace Hud
{
	public class BulletIconsCreator : MonoBehaviour
	{
		[SerializeField] private Transform _bulletIconsHolder;

		private IWeaponReloader _weaponRealoader;
		private IPersistentProgressService _persistentProgressService;
		private IBulletIconFactory _bulletIconFactory;

		[Inject]
		public void Constructor(IWeaponReloader weaponReloader, IPersistentProgressService persistentProgressService,
			IBulletIconFactory bulletIconFactory)
		{
			_weaponRealoader = weaponReloader;
			_persistentProgressService = persistentProgressService;
			_bulletIconFactory = bulletIconFactory;
		}
		private void OnEnable() => 
			_weaponRealoader.WeaponReloaded += CreateBulletIcons;

		private void OnDisable() => 
			_weaponRealoader.WeaponReloaded -= CreateBulletIcons;

		private void Start() => 
			CreateBulletIcons();

		private void CreateBulletIcons()
		{
			DeleteBulletIcons();

			int ammoCount = _persistentProgressService.Progress.CharacterData.WeaponData.MagazineSize;

			Vector2 position = Vector2.zero;

			for (int i = 0; i < ammoCount; i++)
			{
				_bulletIconFactory.Create(_bulletIconsHolder, position);

				position = (i + 1) % Constants.MaxIconsInColumn == 0 ? new Vector2(position.x + Constants.NextIconXPositionStep, 0) :
					new Vector2(position.x, position.y + Constants.NextIconYPositionStep);
			}
		}

		private void DeleteBulletIcons()
		{
			int iconsCount = _bulletIconFactory.BulletIcons.Count;

			if (iconsCount <= 0)
				return;

			for (int i = 0; i < iconsCount; i++)
				_bulletIconFactory.Destroy();

			_bulletIconFactory.BulletIcons.Clear();
		}
	}
}