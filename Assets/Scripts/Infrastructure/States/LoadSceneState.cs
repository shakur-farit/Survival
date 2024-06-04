using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factories.UI;
using Infrastructure.States.StatesMachine;

namespace Infrastructure.States
{
	public class LoadSceneState : IGameState
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IUIFactory _uiFactory;

		public LoadSceneState(IGameStatesSwitcher gameStatesSwitcher, IUIFactory uiFactory)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
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
			_gameStatesSwitcher.SwitchState<MainMenuState>();
	}
}