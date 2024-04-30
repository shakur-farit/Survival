using Cysharp.Threading.Tasks;
using Infrastructure.States.StateMachine;
using UI.Services.Factory;

namespace Infrastructure.States
{
	public class LoadSceneState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly IUIFactory _uiFactory;

		public LoadSceneState(IGameStateMachine gameStateMachine, IUIFactory uiFactory)
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