using EnemyLogic.Mediator;
using Infrastructure.States;

namespace EnemyLogic.States.StateMachine
{
	public abstract class EnemyAimState : IState
	{
		protected EnemyAnimator EnemyAnimator;
		private readonly IEnemyAnimatorMediator _mediator;

		protected EnemyAimState(IEnemyAnimatorMediator mediator) => 
			_mediator = mediator;

		public void Enter()
		{
			SetEnemyAnimator();
			StartAnimation();
		}

		public void Exit() =>
			StopAnimation();

		protected abstract void StartAnimation();

		protected abstract void StopAnimation();

		private void SetEnemyAnimator() => 
			EnemyAnimator = _mediator.Animator;
	}
}