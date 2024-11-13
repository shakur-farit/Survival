using Infrastructure.Services.PersistentProgress;
using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class MainMenuWindow : WindowBase
	{
		[SerializeField] private Button _settingsButton;
		
		private IPersistentProgressService _persistentProgressService;
		private IGameStatesSwitcher _gameStatesSwitcher;
		private IWindowsService _windowsService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IGameStatesSwitcher gameStatesSwitcher,
			IWindowsService windowsService)
		{
			_persistentProgressService = persistentProgressService;
			_gameStatesSwitcher = gameStatesSwitcher;
			_windowsService = windowsService;
		}

		protected override void OnAwake()
		{
			base.OnAwake();

			CloseButton.onClick.AddListener(StartGame);
			_settingsButton.onClick.AddListener(OpenSettingsWindow);
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.MainMenu);

		private void StartGame()
		{
			if(_persistentProgressService.Progress.CharacterData.CurrentCharacter == null)
				return;

			_gameStatesSwitcher.SwitchState<ObjectsPoolCreateState>();
		}

		private void OpenSettingsWindow() => 
			_windowsService.Open(WindowType.Settings);
	}
}
