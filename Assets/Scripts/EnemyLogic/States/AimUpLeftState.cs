namespace EnemyLogic.States
{
	public class AimUpLeftState : EnemyAimState
	{
		protected override void StartAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StartAimUpLeft();

		protected override void StopAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StopAimUpLeft();
	}
}