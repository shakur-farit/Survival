namespace EnemyLogic.States
{
	public class AimDownState : EnemyAimState
	{
		protected override void StartAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StartAimDown();

		protected override void StopAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StopAimDown();
	}
}