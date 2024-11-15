namespace Infrastructure.States.GameStates.StatesMachine
{
	public interface IGameStatesSwitcher
	{
		void SwitchState<TState>() where TState : IGameState;
	}
}