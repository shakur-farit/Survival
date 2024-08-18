using Cysharp.Threading.Tasks;
using UI.Factory;
using UI.Services.Windows;
using UI.Windows;
using Utility;

namespace Infrastructure.States
{
	public class MainMenuState : IGameState
	{
		private readonly IWindowsService _windowsService;
		private readonly IUIFactory _uiFactory;
		private readonly IScenesService _scenesService;

		public MainMenuState(IWindowsService windowsService, IUIFactory uiFactory, IScenesService scenesService)
		{
			_windowsService = windowsService;
			_uiFactory = uiFactory;
			_scenesService = scenesService;
		}

		public async void Enter()
		{
			await SwitchToMainMenuScene();

			await CreateUIRoot();

			await OpenMainMenuWindow();
		}

		public void Exit() => 
			_windowsService.Close(WindowType.MainMenu);

		private async UniTask OpenMainMenuWindow() => 
			await _windowsService.Open(WindowType.MainMenu);

		private async UniTask SwitchToMainMenuScene() => 
			await _scenesService.SwitchSceneTo(Constants.MainMenuScene);

		private async UniTask CreateUIRoot() =>
			await _uiFactory.CreateUIRoot();
	}
}