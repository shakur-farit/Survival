using Infrastructure.Services.PersistentProgress;
using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class LevelCompleteState : IGameState
	{
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IWindowsService _windowService;

		public LevelCompleteState(IPersistentProgressService persistentProgressService, IWindowsService windowService)
		{
			_persistentProgressService = persistentProgressService;
			_windowService = windowService;
		}

		public void Enter() => 
			OpenLevelCompleteWindow();

		public void Exit() =>
			CloseLevelCompleteWindow();

		private void OpenLevelCompleteWindow() =>
			_windowService.Open(WindowType.LevelComplete);

		private void CloseLevelCompleteWindow() =>
			_windowService.Close(WindowType.LevelComplete);

	}
}