using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class MainMenuState : IGameState
	{
		private readonly IWindowsService _windowsService;

		public MainMenuState(IWindowsService windowsService) => 
			_windowsService = windowsService;

		public async void Enter() => 
			await _windowsService.Open(WindowType.MainMenu);

		public void Exit() => 
			_windowsService.Close(WindowType.MainMenu);
	}
}