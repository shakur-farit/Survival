namespace EnemyLogic.States
{
	public class AimUpState : EnemyAimState
	{
		protected override void StartAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StartAimUp();

		protected override void StopAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StopAimUp();
	}
}