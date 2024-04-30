using Infrastructure.States.StateMachine;

namespace Infrastructure.States
{
	public class GameLoopingState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;

		public GameLoopingState(IGameStateMachine gameStateMachine) => 
			_gameStateMachine = gameStateMachine;

		public void Enter() => 
			EnterInLoadLevelState();

		private void EnterInLoadLevelState() => 
			_gameStateMachine.Enter<LoadLevelState>();

		public void Exit()
		{
		}
	}
}