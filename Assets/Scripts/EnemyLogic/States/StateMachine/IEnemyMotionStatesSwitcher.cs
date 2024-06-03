using Infrastructure.States;

namespace EnemyLogic.States.StateMachine
{
	public interface IEnemyMotionStatesSwitcher
	{
		void SwitchState<TState>() where TState : IState;
	}
}