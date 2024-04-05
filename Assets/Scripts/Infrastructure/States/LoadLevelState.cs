using System.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using UnityEngine;

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

		private async Task CreateGameObjects()
		{
			await CreateHero();
			await CreateHud();

		}

		private async Task CreateHud() => 
			await _gameFactory.CreateHud();

		private async Task CreateHero() => 
			await _gameFactory.CreateHero();

		private void EnterInGameLoopingState() => 
			_gameStateMachine.Enter<GameLoopingState>();
	}
}