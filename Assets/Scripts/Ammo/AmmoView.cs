using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		private ITransientGameDataService _transientGameDataService;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService) => 
			_transientGameDataService = transientGameDataService;

		private void OnEnable() => 
			SetupView();

		private void SetupView()
		{
			_spriteRenderer.sprite = _transientGameDataService.Data.CharacterData.WeaponData.CurrentWeapon.Ammo.Sprite;
			_spriteRenderer.material = _transientGameDataService.Data.CharacterData.WeaponData.CurrentWeapon.Ammo.Material;
		}
	}
}