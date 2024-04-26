using Assets.Scripts.UI.Services.Windows;
using Assets.Scripts.UI.Windows;

namespace Assets.Scripts.Infrastructure.States
{
	public class MainMenuState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly WindowsService _windowsService;

		public MainMenuState(GameStateMachine gameStateMachine, WindowsService windowsService)
		{
			_gameStateMachine = gameStateMachine;
			_windowsService = windowsService;
		}

		public async void Enter()
		{
			StaticEventsHandler.OnGameStarted += EnterInGameLoopingState;

			await _windowsService.Open(WindowType.MainMenuWindow);
		}

		public void Exit()
		{
			_windowsService.Close(WindowType.MainMenuWindow);

			StaticEventsHandler.OnGameStarted -= EnterInGameLoopingState;
		}

		private void EnterInGameLoopingState() => 
			_gameStateMachine.Enter<GameLoopingState>();
	}
}