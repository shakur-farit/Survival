using Infrastructure.States.StatesMachine;

namespace Infrastructure.States
{
	public class GameLoopingState : IState
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;

		public GameLoopingState(IGameStatesSwitcher gameStatesSwitcher) => 
			_gameStatesSwitcher = gameStatesSwitcher;

		public void Enter() => 
			EnterInLoadLevelState();

		private void EnterInLoadLevelState() => 
			_gameStatesSwitcher.SwitchState<LoadLevelState>();

		public void Exit()
		{
		}
	}
}