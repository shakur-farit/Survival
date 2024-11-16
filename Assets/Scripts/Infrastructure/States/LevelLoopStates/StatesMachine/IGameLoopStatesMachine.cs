namespace Infrastructure.States.GameLoopStates.StatesMachine
{
	public interface ILevelLoopStatesSwitcher
	{
		void SwitchState<TState>() where TState : ILevelLoopState;
	}
}