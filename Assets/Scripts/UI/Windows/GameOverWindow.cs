using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using UI.Services.Windows;
using Zenject;

namespace UI.Windows
{
	public class GameOverWindow : WindowBase
	{
		private IGameStatesSwitcher _gameStateMachine;
		private IWindowsService _windowService;

		[Inject]
		public void Constructor(IGameStatesSwitcher gameStatesSwitcher, IWindowsService windowsService)
		{
			_gameStateMachine = gameStatesSwitcher;
			_windowService = windowsService;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			
			CloseButton.onClick.AddListener(RestartGame);
		}

		protected override void CloseWindow() => 
			_windowService.Close(WindowType.GameOver);

		private void RestartGame() => 
			_gameStateMachine.SwitchState<MainMenuState>();
	}
}