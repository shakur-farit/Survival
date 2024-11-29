using Effects.SoundEffects.Click;
using Infrastructure.Services.TransientGameData;
using Infrastructure.States.GameStates;
using Infrastructure.States.GameStates.StatesMachine;
using UI.Services.Windows;
using Zenject;

namespace UI.Windows
{
	public class MainMenuWindow : WindowBase
	{
		private ITransientGameDataService _transientGameDataService;
		private IGameStatesSwitcher _gameStatesSwitcher;
		private IWindowsService _windowsService;
		private IDoorsOpeningSoundEffectFactory _doorsOpeningSoundFactory;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService, IGameStatesSwitcher gameStatesSwitcher,
			IWindowsService windowsService, IDoorsOpeningSoundEffectFactory doorsOpeningSoundEffectFactory)
		{
			_transientGameDataService = transientGameDataService;
			_gameStatesSwitcher = gameStatesSwitcher;
			_windowsService = windowsService;
			_doorsOpeningSoundFactory = doorsOpeningSoundEffectFactory;
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
			if(_transientGameDataService.Data.CharacterData.CurrentCharacter == null)
				return;

			_gameStatesSwitcher.SwitchState<ObjectsPoolCreateState>();
		}

		private void MakeClickSound() => 
			_doorsOpeningSoundFactory.Create();
	}
}
