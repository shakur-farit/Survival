using StaticData;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyAnimator : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		private IEnemyAnimatorMediator _mediator;

		[Inject]
		public void Constructor(IEnemyAnimatorMediator mediator) => 
			_mediator = mediator;

		private void Awake() => 
			_mediator.RegisterAnimator(this);

		public void InitializeAnimator(EnemyStaticData staticData) => 
			_animator.runtimeAnimatorController = staticData.Animator;
	}
}