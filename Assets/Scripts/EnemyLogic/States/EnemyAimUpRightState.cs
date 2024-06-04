namespace EnemyLogic.States
{
	public class EnemyAimUpRightState : EnemyState
	{
		protected override void StartAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StartAimUpRight();

		protected override void StopAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StopAimUpRight();
	}
}