using Infrastructure.States;

namespace Character.States.StatesMachine.Aim
{
	public interface ICharacterAimStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IState;
	}
}