using Events;
using Infrastructure.States.StateMachine;
using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class MainMenuState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly WindowsService _windowsService;
		private readonly IGamePlayEvents _eventer;


		public MainMenuState(GameStateMachine gameStateMachine, WindowsService windowsService, IGamePlayEvents eventer)
		{
			_gameStateMachine = gameStateMachine;
			_windowsService = windowsService;
			_eventer = eventer;
		}

		public async void Enter()
		{
			_eventer.OnGameStarted += EnterInGameLoopingState;

			await _windowsService.Open(WindowType.MainMenuWindow);
		}

		public void Exit()
		{
			_windowsService.Close(WindowType.MainMenuWindow);

			_eventer.OnGameStarted -= EnterInGameLoopingState;
		}

		private void EnterInGameLoopingState() => 
			_gameStateMachine.Enter<GameLoopingState>();
	}
}