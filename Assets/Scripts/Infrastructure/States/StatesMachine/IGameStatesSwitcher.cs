namespace Infrastructure.States.StatesMachine
{
	public interface IGameStatesSwitcher
	{
		void SwitchState<TState>() where TState : IGameState;
	}
}