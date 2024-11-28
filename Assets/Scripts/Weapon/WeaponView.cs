using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.TransientGameData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Weapon
{
	public class WeaponView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _weaponSpriteRenderer;

		private ITransientGameDataService _transientGameDataService;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService, IStaticDataService staticDataService)
		{
			_transientGameDataService = transientGameDataService;
			_staticDataService = staticDataService;
		}

		public void SetupView()
		{
			foreach (WeaponStaticData weapon in _staticDataService.WeaponsListStaticData.WeaponsList)
			{
				if (weapon.Type == _transientGameDataService.Data.CharacterData.WeaponData.CurrentWeapon.Type)
				{
					_transientGameDataService.Data.CharacterData.WeaponData.CurrentWeapon = weapon;

					_weaponSpriteRenderer.sprite = weapon.Sprite;
				}
			}
		}
	}
}
