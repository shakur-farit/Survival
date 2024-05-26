using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factories.UI;
using Infrastructure.States.StateMachine;

namespace Infrastructure.States
{
	public class LoadSceneState : IState
	{
		private readonly IGameStateSwitcher _gameStateSwitcher;
		private readonly IUIFactory _uiFactory;

		public LoadSceneState(IGameStateSwitcher gameStateSwitcher, IUIFactory uiFactory)
		{
			_gameStateSwitcher = gameStateSwitcher;
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
			_gameStateSwitcher.SwitchState<MainMenuState>();
	}
}