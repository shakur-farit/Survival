using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using UI.Services.Factory;

namespace Infrastructure.States
{
	public class LoadSceneState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly AssetsProvider _assertsProvider;
		private readonly UIFactory _uiFactory;

		public LoadSceneState(GameStateMachine gameStateMachine, AssetsProvider assertsProvider, UIFactory uiFactory)
		{
			_gameStateMachine = gameStateMachine;
			_assertsProvider = assertsProvider;
			_uiFactory = uiFactory;
		}

		public async void Enter()
		{
			InitializeAddressables();

			await CreateUIRoot();

			EnterInMainMenuState();
		}

		private async UniTask CreateUIRoot() => 
			await _uiFactory.CreateUIRoot();

		public void Exit()
		{
		}

		private void InitializeAddressables() =>
			_assertsProvider.Initialize();

		private void EnterInMainMenuState() => 
			_gameStateMachine.Enter<MainMenuState>();
	}
}