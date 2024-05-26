using Infrastructure.States;

namespace Character.States.StateMachine
{
	public interface ICharacterStatesSwitcher
	{
		void SwitchState<TState>() where TState : IState;
	}
}