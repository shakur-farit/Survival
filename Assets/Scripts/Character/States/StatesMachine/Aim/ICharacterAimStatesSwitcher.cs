using Infrastructure.States;

namespace Character.States.StatesMachine.Aim
{
	public interface ICharacterAimStatesSwitcher
	{
		void SwitchState<TState>() where TState : IState;
	}
}