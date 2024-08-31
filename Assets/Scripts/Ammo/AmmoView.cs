using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void OnEnable() => 
			SetupView();

		private void SetupView()
		{
			_spriteRenderer.sprite = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Ammo.Sprite;
			_spriteRenderer.material = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Ammo.Material;
		}
	}
}