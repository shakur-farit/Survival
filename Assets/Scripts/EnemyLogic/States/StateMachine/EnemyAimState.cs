using Infrastructure.States;

namespace EnemyLogic.States.StateMachine
{
	public abstract class EnemyAimState : IEnemyAnimatorState
	{
		public void Enter(EnemyAnimator enemyAnimator) => 
			StartAnimation(enemyAnimator);

		public void Exit(EnemyAnimator enemyAnimator) =>
			StopAnimation(enemyAnimator);

		protected abstract void StartAnimation(EnemyAnimator enemyAnimator);

		protected abstract void StopAnimation(EnemyAnimator enemyAnimator);
	}

	public class AimDownState : EnemyAimState
	{
		protected override void StartAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StartAimDown();

		protected override void StopAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StopAimDown();
	}
}