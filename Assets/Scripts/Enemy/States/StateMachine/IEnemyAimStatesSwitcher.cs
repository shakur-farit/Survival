namespace Enemy.States.StateMachine
{
	public interface IEnemyAimStatesSwitcher
	{
		void SwitchState<TState>(EnemyAnimator enemyAnimator) where TState : IEnemyAnimatorState;
	}
}