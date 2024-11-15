namespace Infrastructure.States.GameLoopStates.StatesMachine
{
	public interface IGameLoopStatesSwitcher
	{
		void SwitchState<TState>() where TState : IGameLoopState;
	}
}