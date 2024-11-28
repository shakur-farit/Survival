using Effects.SoundEffects.Click.Factory;
using Infrastructure.Services.PersistentProgress;
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
		private IClickSoundEffectFactory _clickSoundFactory;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService, IGameStatesSwitcher gameStatesSwitcher,
			IWindowsService windowsService, IClickSoundEffectFactory clickSoundFactory)
		{
			_transientGameDataService = transientGameDataService;
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
			if(_transientGameDataService.Data.CharacterData.CurrentCharacter == null)
				return;

			_gameStatesSwitcher.SwitchState<ObjectsPoolCreateState>();
		}

		private void MakeClickSound() => 
			_clickSoundFactory.Create();
	}
}
