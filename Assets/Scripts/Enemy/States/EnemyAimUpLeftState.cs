namespace Enemy.States
{
	public class EnemyAimUpLeftState : EnemyState
	{
		protected override void StartAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StartAimUpLeft();

		protected override void StopAnimation(EnemyAnimator enemyAnimator) => 
			enemyAnimator.StopAimUpLeft();
	}
}