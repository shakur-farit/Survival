using Events;
using Infrastructure.States.StateMachine;
using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class MainMenuState : IState
	{
		private readonly IGameStateSwitcher _gameStateSwitcher;
		private readonly IWindowsService _windowsService;
		private readonly IGamePlayEvents _eventer;


		public MainMenuState(IGameStateSwitcher gameStateSwitcher, IWindowsService windowsService, IGamePlayEvents eventer)
		{
			_gameStateSwitcher = gameStateSwitcher;
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
			_gameStateSwitcher.SwitchState<GameLoopingState>();
	}
}