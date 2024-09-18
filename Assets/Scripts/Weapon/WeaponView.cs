using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Weapon
{
	public class WeaponView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _weaponSpriteRenderer;

		private IPersistentProgressService _persistentProgressService;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IStaticDataService staticDataService)
		{
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		public void SetupView()
		{
			foreach (WeaponStaticData weapon in _staticDataService.WeaponsListStaticData.WeaponsList)
			{
				if (weapon.Type == _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Type)
				{
					_persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon = weapon;

					_weaponSpriteRenderer.sprite = weapon.Sprite;
				}
			}
		}
	}
}
