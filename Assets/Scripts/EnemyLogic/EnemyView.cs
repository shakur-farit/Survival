using StaticData;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer BodySpriteRenderer;

		private IEnemyMediator _mediator;

		[Inject]
		public void Constructor(IEnemyMediator mediator) => 
			_mediator = mediator;

		private void Awake() => 
			_mediator.RegisterView(this);

		public void InitializeSprite(EnemyStaticData enemyStaticData) => 
			BodySpriteRenderer.sprite = enemyStaticData.Sprite;
	}
}