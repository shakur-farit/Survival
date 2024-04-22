using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;

namespace Infrastructure.States
{
	public class LoadLevelState : IState
	{
		private readonly GameFactory _gameFactory;
		private readonly GameStateMachine _gameStateMachine;
		private readonly AssetsProvider _assertsProvider;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly StaticDataService _staticDataService;

		public LoadLevelState(GameStateMachine gameStateMachine, GameFactory gameFactory, AssetsProvider assertsProvider, 
			PersistentProgressService persistentProgressService, StaticDataService staticDataService)
		{
			_gameStateMachine = gameStateMachine;
			_gameFactory = gameFactory;
			_assertsProvider = assertsProvider;
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		public async void Enter()
		{
			await CreateGameObjects();
		}

		public void Exit()
		{
		}

		private async UniTask CreateGameObjects()
		{
			await CreateCharacter();
			await CreateSpawner();
			await CreateHud();
		}

		private async UniTask CreateCharacter()
		{ 
			await _gameFactory.CreateCharacter();
		}

		private async UniTask CreateSpawner() => 
			await _gameFactory.CreateSpawner();

		private async UniTask CreateHud() => 
			await _gameFactory.CreateHud();

	}
}