using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Hero
{
	public class HeroScript : MonoBehaviour
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

			bodySprite.sprite = _staticDataService.ForHero.BodySprite;
			animatorController.runtimeAnimatorController = _staticDataService.ForHero.Controller;
			handSprite.sprite = _staticDataService.ForHero.HandSprite;
			handNoWeaponSprite.sprite = _staticDataService.ForHero.HandSprite;
		}
	}
}
