using Infrastructure.Services.PersistentProgress;
using Soundtrack;
using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class LevelCompleteState : IGameState
	{
		private readonly IWindowsService _windowService;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IMusicSwitcher _musicSwitcher;

		public LevelCompleteState(IWindowsService windowService, IPersistentProgressService persistentProgressService, 
			IMusicSwitcher musicSwitcher)
		{
			_windowService = windowService;
			_persistentProgressService = persistentProgressService;
			_musicSwitcher = musicSwitcher;
		}

		public void Enter()
		{
			OpenLevelCompleteWindow();

			_musicSwitcher.PlayDungeonMelancholy();
		}

		public void Exit() => 
			ClearShopUsedWeaponTypesList();

		private void OpenLevelCompleteWindow() =>
			_windowService.Open(WindowType.LevelComplete);

		private void ClearShopUsedWeaponTypesList() => 
			_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Clear();
	}
}