using Infrastructure.States;

namespace Character.States.StatesMachine.Motion
{
	public interface ICharacterMotionStatesSwitcher
	{
		void SwitchState<TState>() where TState : IState;
	}
}