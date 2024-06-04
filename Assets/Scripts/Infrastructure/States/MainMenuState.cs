using Events;
using Infrastructure.States.StatesMachine;
using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class MainMenuState : IGameState
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IWindowsService _windowsService;
		private readonly IGamePlayEvents _eventer;


		public MainMenuState(IGameStatesSwitcher gameStatesSwitcher, IWindowsService windowsService, IGamePlayEvents eventer)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
			_windowsService = windowsService;
			_eventer = eventer;
		}

		public async void Enter()
		{
			_eventer.GameStarted += EnterInGameLoopingState;

			await _windowsService.Open(WindowType.MainMenuWindow);
		}

		public void Exit()
		{
			_windowsService.Close(WindowType.MainMenuWindow);

			_eventer.GameStarted -= EnterInGameLoopingState;
		}

		private void EnterInGameLoopingState() => 
			_gameStatesSwitcher.SwitchState<GameLoopingState>();
	}
}