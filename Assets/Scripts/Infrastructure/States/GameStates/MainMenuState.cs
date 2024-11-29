using Cysharp.Threading.Tasks;
using Infrastructure.Services.SceneManagement;
using Pool;
using Selector.Factory;
using Soundtrack;
using Soundtrack.Factory;
using UI.Factory;
using UI.Services.Windows;
using UI.Windows;
using UnityEngine;
using Utility;

namespace Infrastructure.States.GameStates
{
	public class MainMenuState : IGameState
	{
		private readonly IWindowsService _windowsService;
		private readonly IUIFactory _uiFactory;
		private readonly IScenesService _scenesService;
		private readonly ICharacterSelectorFactory _characterSelectorFactory;
		private readonly IMusicSourceFactory _musicSourceFactory;
		private readonly IMusicSwitcher _musicSwitcher;
		private readonly IPoolFactory _poolFactory;

		public MainMenuState(IWindowsService windowsService, IUIFactory uiFactory, 
			IScenesService scenesService, ICharacterSelectorFactory characterSelectorFactory, 
			IMusicSourceFactory musicSourceFactory, IMusicSwitcher musicSwitcher, IPoolFactory poolFactory)
		{
			_windowsService = windowsService;
			_uiFactory = uiFactory;
			_scenesService = scenesService;
			_characterSelectorFactory = characterSelectorFactory;
			_musicSourceFactory = musicSourceFactory;
			_musicSwitcher = musicSwitcher;
			_poolFactory = poolFactory;
		}

		public async void Enter()
		{
			await SwitchToMainMenuScene();
			await CreateUIRoot();
			await OpenMainMenuWindow();
			await CreateClickSoundEffectsPool();
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

		private async UniTask CreateClickSoundEffectsPool()
		{
			await _poolFactory.CreatePool(PooledObjectType.ClickSoundEffect);
			await _poolFactory.CreatePool(PooledObjectType.DoorsOpeningSoundEffect);
		}

		private void DestroySelector() => 
			_characterSelectorFactory.Destroy();
	}
}