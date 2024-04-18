using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterScript : MonoBehaviour
	{
		public GameObject Body;
		public GameObject Hand;
		public GameObject HandNoWeapon;

		private StaticDataService _staticDataService;

		[Inject]
		public void Constructor(StaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Start()
		{
			Body.TryGetComponent<SpriteRenderer>(out SpriteRenderer bodySprite);
			Body.TryGetComponent<Animator>(out Animator animatorController);
			Hand.TryGetComponent<SpriteRenderer>(out SpriteRenderer handSprite);
			HandNoWeapon.TryGetComponent<SpriteRenderer>(out SpriteRenderer handNoWeaponSprite);

			bodySprite.sprite = _staticDataService.ForCharacter.BodySprite;
			animatorController.runtimeAnimatorController = _staticDataService.ForCharacter.Controller;
			handSprite.sprite = _staticDataService.ForCharacter.HandSprite;
			handNoWeaponSprite.sprite = _staticDataService.ForCharacter.HandSprite;
		}
	}
}
