using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Zenject;

namespace Hud
{
	public class AmmoBar : MonoBehaviour
	{
		[SerializeField] private Transform _ammoIconsHolder;

		private IPersistentProgressService _persistentProgressService;
		private IAmmoIconFactory _ammoIconFactory;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IAmmoIconFactory ammoIconFactory)
		{
			_persistentProgressService = persistentProgressService;
			_ammoIconFactory = ammoIconFactory;
		}

		private void Start() => 
			CreateAmmoIcons();

		private void OnDestroy() => 
			ClearIconsList();

		public void UpdateAmmoIcons()
		{
			int currentAmmoCount = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentAmmoCount;
			
			List<GameObject> ammoIcons = _ammoIconFactory.AmmoIcons;

			for (int i = 0; i < ammoIcons.Count; i++)
				ammoIcons[i].SetActive(i < currentAmmoCount);
		}

		public void CreateAmmoIcons()
		{
			ClearIconsList();

			int ammoCount = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentAmmoCount;

			Vector2 position = Vector2.zero;

			for (int i = 0; i < ammoCount; i++)
			{
				_ammoIconFactory.Create(_ammoIconsHolder, position);

				position = (i + 1) % Constants.MaxBulletIconsInColumn == 0 ? new Vector2(position.x + Constants.NextBulletIconXPositionStep, 0) :
					new Vector2(position.x, position.y + Constants.NextBulletIconYPositionStep);
			}
		}

		private void ClearIconsList()
		{
			foreach (GameObject ammoIcon in _ammoIconFactory.AmmoIcons)
				_ammoIconFactory.Destroy(ammoIcon);

			_ammoIconFactory.AmmoIcons.Clear();
		}
	}
}