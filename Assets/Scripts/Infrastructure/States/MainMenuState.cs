using Cysharp.Threading.Tasks;
using Infrastructure.Services.SceneManagement;
using Selector.Factory;
using Soundtrack;
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
		private readonly ICharacterSelectorFactory _characterSelectorFactory;
		private readonly IMusicSourceFactory _musicSourceFactory;
		private readonly IMusicSwitcher _musicSwitcher;

		public MainMenuState(IWindowsService windowsService, IUIFactory uiFactory, 
			IScenesService scenesService, ICharacterSelectorFactory characterSelectorFactory, 
			IMusicSourceFactory musicSourceFactory, IMusicSwitcher musicSwitcher)
		{
			_windowsService = windowsService;
			_uiFactory = uiFactory;
			_scenesService = scenesService;
			_characterSelectorFactory = characterSelectorFactory;
			_musicSourceFactory = musicSourceFactory;
			_musicSwitcher = musicSwitcher;
		}

		public async void Enter()
		{
			await SwitchToMainMenuScene();
			await CreateUIRoot();
			await OpenMainMenuWindow();
			await CreateCharacterSelector();
			await CreateMusicHolder();
			PlayMainMenuMusic();
		}

		public void Exit() => 
			DestroySelector();

		private async UniTask OpenMainMenuWindow() => 
			await _windowsService.Open(WindowType.MainMenu);

		private async UniTask SwitchToMainMenuScene() => 
			await _scenesService.SwitchSceneTo(Constants.MainMenuScene);

		private async UniTask CreateUIRoot() => 
			await _uiFactory.CreateUIRoot();

		private async UniTask CreateCharacterSelector() => 
			await _characterSelectorFactory.Create();

		private async UniTask CreateMusicHolder() => 
			await _musicSourceFactory.Create();

		private void PlayMainMenuMusic() => 
			_musicSwitcher.PlayMainMenu();

		private void DestroySelector() => 
			_characterSelectorFactory.Destroy();
	}
}