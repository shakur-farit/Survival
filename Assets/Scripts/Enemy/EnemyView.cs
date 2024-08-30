using Enemy.Mediator;
using StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer BodySpriteRenderer;

		private IEnemyViewMediator _mediator;

		[Inject]
		public void Constructor(IEnemyViewMediator mediator) => 
			_mediator = mediator;

		private void OnEnable() => 
			_mediator.RegisterView(this);

		public void SetupSprite(EnemyStaticData enemyStaticData) => 
			BodySpriteRenderer.sprite = enemyStaticData.Sprite;
	}
}