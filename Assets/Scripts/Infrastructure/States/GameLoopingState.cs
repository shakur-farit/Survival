using Infrastructure.States.StateMachine;

namespace Infrastructure.States
{
	public class GameLoopingState : IState
	{
		private readonly IGameStateSwitcher _gameStateSwitcher;

		public GameLoopingState(IGameStateSwitcher gameStateSwitcher) => 
			_gameStateSwitcher = gameStateSwitcher;

		public void Enter() => 
			EnterInLoadLevelState();

		private void EnterInLoadLevelState() => 
			_gameStateSwitcher.SwitchState<LoadLevelState>();

		public void Exit()
		{
		}
	}
}