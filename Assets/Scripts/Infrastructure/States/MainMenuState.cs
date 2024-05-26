using Events;
using Infrastructure.States.StateMachine;
using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class MainMenuState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly IWindowsService _windowsService;
		private readonly IGamePlayEvents _eventer;


		public MainMenuState(IGameStateMachine gameStateMachine, IWindowsService windowsService, IGamePlayEvents eventer)
		{
			_gameStateMachine = gameStateMachine;
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
			_gameStateMachine.Enter<GameLoopingState>();
	}
}