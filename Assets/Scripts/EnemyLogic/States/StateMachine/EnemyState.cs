using Infrastructure.Services.Factories.Enemy;
using Infrastructure.States;

namespace EnemyLogic.States.StateMachine
{
	public abstract class EnemyState : IState
	{
		protected EnemyAnimator EnemyAnimator;

		private readonly IEnemyFactory _enemyFactory;

		protected EnemyState(IEnemyFactory enemyFactory) =>
			_enemyFactory = enemyFactory;

		public void Enter()
		{
			SetEnemyAnimator();
			StartAnimation();
		}

		public void Exit() =>
			StopAnimation();

		protected abstract void StartAnimation();

		protected abstract void StopAnimation();

		private void SetEnemyAnimator()
		{
			
		}
	}
}