namespace Infrastructure.States.StatesMachine
{
	public interface IGameStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IGameState;
	}
}