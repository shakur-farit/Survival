namespace Enemy.States
{
	public interface IEnemyAnimatorState
	{
		void Enter(EnemyAnimator enemyAnimator);
		void Exit(EnemyAnimator enemyAnimator);
	}
}