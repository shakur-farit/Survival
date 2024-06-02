using StaticData;
using UI.Windows;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterView : MonoBehaviour
	{
		public SpriteRenderer Hand;
		public SpriteRenderer HandNoWeapon;

		private ICharacterViewMediator _mediator;

		[Inject]
		public void Constructor(ICharacterViewMediator mediator) =>
			_mediator = mediator;

		private void Awake() => 
			_mediator.RegisterView(this);

		public void SetupSprite(CharacterStaticData staticData)
		{
			Hand.sprite = staticData.HandSprite;
			HandNoWeapon.sprite = staticData.HandSprite;
		}
	}
}