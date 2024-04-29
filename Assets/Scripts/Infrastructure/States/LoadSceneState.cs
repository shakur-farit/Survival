using Cysharp.Threading.Tasks;
using Infrastructure.States.StateMachine;
using UI.Services.Factory;

namespace Infrastructure.States
{
	public class LoadSceneState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly UIFactory _uiFactory;

		public LoadSceneState(GameStateMachine gameStateMachine, UIFactory uiFactory)
		{
			_gameStateMachine = gameStateMachine;
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