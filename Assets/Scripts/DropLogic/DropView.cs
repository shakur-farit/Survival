using DropLogic.Mediator;
using StaticData;
using UnityEngine;
using Zenject;

namespace DropLogic
{
	public class DropView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		private IDropViewMediator _mediator;

		[Inject]
		public void Constructor(IDropViewMediator mediator) => 
			_mediator = mediator;

		private void Awake() => 
			_mediator.RegisterView(this);

		public void SetupView(DropStaticData dropStaticData) => 
			_spriteRenderer.sprite = dropStaticData.Sprite;
	}
}