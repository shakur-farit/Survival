using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Factories.Hud;
using Infrastructure.Services.PersistentProgress;
using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class LevelComplete : IGameState
	{
		private readonly IHudFactory _hudFactory;
		private readonly ICharacterFactory _characterFactory;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IWindowsService _windowService;

		public LevelComplete(IHudFactory hudFactory, ICharacterFactory characterFactory,
			IPersistentProgressService persistentProgressService, IWindowsService windowService)
		{
			_hudFactory = hudFactory;
			_characterFactory = characterFactory;
			_persistentProgressService = persistentProgressService;
			_windowService = windowService;
		}

		public void Enter()
		{
			OpenLevelCompleteWindow();
			DestroyHud();
			DestroyCharacter();
			InitNextLevel();
		}

		public void Exit() =>
			CloseLevelCompleteWindow();

		private void OpenLevelCompleteWindow() =>
			_windowService.Open(WindowType.LevelComplete);

		private void CloseLevelCompleteWindow() =>
			_windowService.Close(WindowType.LevelComplete);

		private void DestroyCharacter() => 
			_characterFactory.Destroy();

		private void DestroyHud() =>
			_hudFactory.Destroy();

		private void InitNextLevel() =>
			_persistentProgressService.Progress.LevelData.CurrentLevel += 1;
	}
}