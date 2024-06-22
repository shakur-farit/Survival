using Infrastructure.Services.PersistentProgress;
using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class LevelCompleteState : IGameState
	{
		private readonly IWindowsService _windowService;
		private readonly IPersistentProgressService _persistentProgressService;

		public LevelCompleteState(IWindowsService windowService, IPersistentProgressService persistentProgressService)
		{
			_windowService = windowService;
			_persistentProgressService = persistentProgressService;
		}

		public void Enter() => 
			OpenLevelCompleteWindow();

		public void Exit()
		{
			ClearShopUsedWeaponTypesList();
			CloseLevelCompleteWindow();
		}

		private void OpenLevelCompleteWindow() =>
			_windowService.Open(WindowType.LevelComplete);

		private void CloseLevelCompleteWindow() =>
			_windowService.Close(WindowType.LevelComplete);

		private void ClearShopUsedWeaponTypesList() => 
			_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Clear();
	}
}