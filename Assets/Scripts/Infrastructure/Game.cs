using Assets.Scripts.Infrastructure.States;

namespace Assets.Scripts.Infrastructure
{
	public class Game
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly StatesFactory _statesFactory;

		public Game(GameStateMachine gameStateMachine, StatesFactory statesFactory)
		{
			_gameStateMachine = gameStateMachine;
			_statesFactory = statesFactory;
		}
			

		public void StartGameStateMachine()
		{
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadStaticDataState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadProgressState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadSceneState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<MainMenuState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<GameLoopingState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadLevelState>());

			_gameStateMachine.Enter<LoadStaticDataState>();
		}
	}
}