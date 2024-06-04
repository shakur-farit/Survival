namespace EnemyLogic.States
{
	public class EnemyAimLeftState : EnemyState
	{
		protected override void StartAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StartAimLeft();

		protected override void StopAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StopAimLeft();
	}
}