using Infrastructure.States;

namespace EnemyLogic.States.StateMachine
{
	public interface IEnemyAimStatesSwitcher
	{
		void SwitchState<TState>(EnemyAnimator enemyAnimator) where TState : IEnemyAnimatorState;
	}
}