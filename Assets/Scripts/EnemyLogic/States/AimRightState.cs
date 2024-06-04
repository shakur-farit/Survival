namespace EnemyLogic.States
{
	public class AimRightState : EnemyAimState
	{
		protected override void StartAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StartAimRight();

		protected override void StopAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StopAimRight();
	}
}