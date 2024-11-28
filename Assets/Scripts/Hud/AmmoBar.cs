using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using System.Collections.Generic;
using Infrastructure.Services.TransientGameData;
using UnityEngine;
using Utility;
using Zenject;

namespace Hud
{
	public class AmmoBar : MonoBehaviour
	{
		[SerializeField] private Transform _ammoIconsHolder;

		private ITransientGameDataService _transientGameDataService;
		private IAmmoIconFactory _ammoIconFactory;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService, IAmmoIconFactory ammoIconFactory)
		{
			_transientGameDataService = transientGameDataService;
			_ammoIconFactory = ammoIconFactory;
		}

		private void Start() => 
			CreateAmmoIcons();

		private void OnDisable() => 
			ClearIconsList();

		public void UpdateAmmoIcons()
		{
			int currentAmmoCount = _transientGameDataService.Data.CharacterData.WeaponData.CurrentAmmoCount;
			
			List<GameObject> ammoIcons = _ammoIconFactory.AmmoIcons;

			for (int i = 0; i < ammoIcons.Count; i++)
				ammoIcons[i].SetActive(i < currentAmmoCount);
		}

		public void CreateAmmoIcons()
		{
			ClearIconsList();

			int ammoCount = _transientGameDataService.Data.CharacterData.WeaponData.CurrentAmmoCount;

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