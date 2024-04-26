using Assets.Scripts.Infrastructure.Services.AssetsManagement;
using Assets.Scripts.UI.Services.Factory;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.States
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
			await CreateUIRoot();

			EnterInMainMenuState();
		}

		private async UniTask CreateUIRoot() => 
			await _uiFactory.CreateUIRoot();

		public void Exit()
		{
		}

		private void EnterInMainMenuState() => 
			_gameStateMachine.Enter<MainMenuState>();
	}
}