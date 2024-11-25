namespace Infrastructure.States.LevelLoopStates.StatesMachine
{
	public interface ILevelLoopStatesSwitcher
	{
		void SwitchState<TState>() where TState : ILevelLoopState;
	}
}