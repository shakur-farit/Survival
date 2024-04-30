using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Weapon
{
	public class WeaponView : MonoBehaviour
	{
		public SpriteRenderer WeaponSpriteRenderer;

		private IPersistentProgressService _persistentProgressService;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IStaticDataService staticDataService)
		{
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		private void Start()
		{
			foreach (WeaponStaticData weapon in _staticDataService.WeaponsList)
			{
				if (weapon.Type == _persistentProgressService.Progress.characterData.CurrentCharacterStaticData.DefaultWeapon)
				{
					_persistentProgressService.Progress.characterData.CurrentWeapon = weapon;


					WeaponSpriteRenderer.sprite = weapon.Sprite;
				}
			}
		}
	}
}