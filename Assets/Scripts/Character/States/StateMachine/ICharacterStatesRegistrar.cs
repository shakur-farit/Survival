using Infrastructure.States;

namespace Character.States.StateMachine
{
	public interface ICharacterStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IState;
	}
}