using Effects.SoundEffects.Shot;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.States;
using Infrastructure.States.GameStates;
using Infrastructure.States.GameStates.StatesMachine;
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
		private IClickSoundEffectFactory _clickSoundFactory;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IGameStatesSwitcher gameStatesSwitcher,
			IWindowsService windowsService, IClickSoundEffectFactory clickSoundFactory)
		{
			_persistentProgressService = persistentProgressService;
			_gameStatesSwitcher = gameStatesSwitcher;
			_windowsService = windowsService;
			_clickSoundFactory = clickSoundFactory;
		}

		protected override void OnAwake()
		{
			base.OnAwake();

			CloseButton.onClick.AddListener(StartGame);
			_settingsButton.onClick.AddListener(OpenSettingsWindow);
			_settingsButton.onClick.AddListener(MakeClick);
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

		private void MakeClick() => 
			_clickSoundFactory.Create();
	}
}
