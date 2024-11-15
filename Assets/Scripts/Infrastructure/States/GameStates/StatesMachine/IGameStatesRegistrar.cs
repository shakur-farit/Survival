namespace Infrastructure.States.GameStates.StatesMachine
{
	public interface IGameStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IGameState;
	}
}