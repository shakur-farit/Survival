using Infrastructure.Services.PersistentProgress;
using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using Zenject;

namespace UI.Windows
{
	public class MainMenuWindow : WindowBass
	{
		private IPersistentProgressService _persistentProgressService;
		private IGameStatesSwitcher _gameStatesSwitcher;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IGameStatesSwitcher gameStatesSwitcher)
		{
			_persistentProgressService = persistentProgressService;
			_gameStatesSwitcher = gameStatesSwitcher;
		}

		protected override void OnAwake() => 
			ActionButton.onClick.AddListener(StartGame);

		private void StartGame()
		{
			if(_persistentProgressService.Progress.CharacterData.CurrentCharacter == null)
				return;

			_gameStatesSwitcher.SwitchState<LoadLevelState>();
		}
	}
}
