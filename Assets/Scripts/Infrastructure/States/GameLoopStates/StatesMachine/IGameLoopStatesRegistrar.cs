namespace Infrastructure.States.GameLoopStates.StatesMachine
{
	public interface IGameLoopStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IGameLoopState;

	}
}