namespace Infrastructure.States.LevelLoopStates.StatesMachine
{
	public interface ILevelLoopStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : ILevelLoopState;

	}
}