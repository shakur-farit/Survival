using Effects.SoundEffects.Click.Factory;
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
		}

		protected override void CloseWindow()
		{
			MakeClickSound();

			_windowsService.Close(WindowType.MainMenu);
		}

		private void StartGame()
		{
			if(_persistentProgressService.Progress.CharacterData.CurrentCharacter == null)
				return;

			_gameStatesSwitcher.SwitchState<ObjectsPoolCreateState>();
		}

		private void MakeClickSound() => 
			_clickSoundFactory.Create();
	}
}
