namespace Enemy.States
{
	public abstract class EnemyState : IEnemyAnimatorState
	{
		public void Enter(EnemyAnimator enemyAnimator) => 
			StartAnimation(enemyAnimator);

		public void Exit(EnemyAnimator enemyAnimator) => 
			StopAnimation(enemyAnimator);

		protected abstract void StartAnimation(EnemyAnimator enemyAnimator);

		protected abstract void StopAnimation(EnemyAnimator enemyAnimator);
	}
}