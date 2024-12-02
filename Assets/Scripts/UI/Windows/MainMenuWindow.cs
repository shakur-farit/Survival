using Effects.SoundEffects.Click;
using Effects.SoundEffects.DoorsOpening.Factory;
using Effects.SoundEffects.Error.Factory;
using Infrastructure.Services.NameValidator;
using Infrastructure.Services.TransientGameData;
using Infrastructure.States.GameStates;
using Infrastructure.States.GameStates.StatesMachine;
using TMPro;
using UI.Services.Windows;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
	public class MainMenuWindow : WindowBase
	{
		[SerializeField] private TMP_InputField _inputField;

		private ITransientGameDataService _transientGameDataService;
		private IGameStatesSwitcher _gameStatesSwitcher;
		private IWindowsService _windowsService;
		private IDoorsOpeningSoundEffectFactory _doorsOpeningSoundFactory;
		private INameValidatorService _nameValidatorService;
		private IErrorSoundEffectFactory _errorSoundEffectFactory;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService, IGameStatesSwitcher gameStatesSwitcher,
			IWindowsService windowsService, IDoorsOpeningSoundEffectFactory doorsOpeningSoundEffectFactory,
			IErrorSoundEffectFactory errorSoundEffectFactory,INameValidatorService nameValidatorService)
		{
			_transientGameDataService = transientGameDataService;
			_gameStatesSwitcher = gameStatesSwitcher;
			_windowsService = windowsService;
			_doorsOpeningSoundFactory = doorsOpeningSoundEffectFactory;
			_nameValidatorService = nameValidatorService;
			_errorSoundEffectFactory = errorSoundEffectFactory;
		}

		protected override void OnAwake() => 
			CloseButton.onClick.AddListener(StartGame);

		private void StartGame()
		{
			if (CanStartGame() == false)
			{
				MakeErrorSound();
				return;
			}

			MakeClickSound();

			CloseWindow();

			SwitchToObjectsPoolCreateState();
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.MainMenu);

		private bool CanStartGame()
		{
			if(_transientGameDataService.Data.CharacterData.CurrentCharacter == null)
				return false;

			string characterName = _inputField.text.Trim();

			if(_nameValidatorService.IsNameValidate(characterName) == false)
				return false;

			return true;
		}

		private void MakeClickSound() => 
			_doorsOpeningSoundFactory.Create();

		private void SwitchToObjectsPoolCreateState() => 
			_gameStatesSwitcher.SwitchState<ObjectsPoolCreateState>();

		private void MakeErrorSound() => 
			_errorSoundEffectFactory.Create();
	}
}
