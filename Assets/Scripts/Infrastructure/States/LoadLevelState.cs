using Infrastructure.Services.Factory;

namespace Infrastructure.States
{
	public class LoadLevelState : IState
	{
		private readonly GameFactory _gameFactory;
		private readonly GameStateMachine _gameStateMachine;

		public LoadLevelState(GameStateMachine gameStateMachine, GameFactory gameFactory)
		{
			_gameStateMachine = gameStateMachine;
			_gameFactory = gameFactory;
		}

		public void Enter()
		{
			CreateGameObjects();

			EnterInGameLoopingState();
		}

		public void Exit()
		{
		}

		private void CreateGameObjects()
		{
			CreateHero();
			CreateHud();
		}

		private void CreateHud() => 
			_gameFactory.CreateHud();

		private void CreateHero() => 
			_gameFactory.CreateHero();

		private void EnterInGameLoopingState() => 
			_gameStateMachine.Enter<GameLoopingState>();
	}
}