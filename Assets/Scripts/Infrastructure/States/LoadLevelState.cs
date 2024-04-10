using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;

namespace Infrastructure.States
{
	public class LoadLevelState : IState
	{
		private readonly GameFactory _gameFactory;
		private readonly GameStateMachine _gameStateMachine;
		private readonly AssetsProvider _assertsProvider;

		public LoadLevelState(GameStateMachine gameStateMachine, GameFactory gameFactory, AssetsProvider assertsProvider)
		{
			_gameStateMachine = gameStateMachine;
			_gameFactory = gameFactory;
			_assertsProvider = assertsProvider;
		}

		public async void Enter()
		{
			InitializeAddressables();

			await CreateGameObjects();

			EnterInGameLoopingState();
		}

		public void Exit()
		{
		}

		private void InitializeAddressables() => 
			_assertsProvider.Initialize();

		private async UniTask CreateGameObjects()
		{
			await CreateHero();
			await CreateSpawner();
			await CreateHud();
		}

		private async UniTask CreateHero() => 
			await _gameFactory.CreateHero();

		private async UniTask CreateSpawner() => 
			await _gameFactory.CreateSpawner();

		private async UniTask CreateHud() => 
			await _gameFactory.CreateHud();

		private void EnterInGameLoopingState() => 
			_gameStateMachine.Enter<GameLoopingState>();
	}
}