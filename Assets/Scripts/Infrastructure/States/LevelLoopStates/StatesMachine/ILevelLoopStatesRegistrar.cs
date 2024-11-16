namespace Infrastructure.States.GameLoopStates.StatesMachine
{
	public interface ILevelLoopStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : ILevelLoopState;

	}
}