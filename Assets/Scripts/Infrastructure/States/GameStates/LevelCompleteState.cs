using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using Soundtrack;
using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States.GameStates
{
	public class LevelCompleteState : IGameState
	{
		private readonly IWindowsService _windowService;
		private readonly ITransientGameDataService _transientGameDataService;
		private readonly IMusicSwitcher _musicSwitcher;

		public LevelCompleteState(IWindowsService windowService, ITransientGameDataService transientGameDataService, 
			IMusicSwitcher musicSwitcher)
		{
			_windowService = windowService;
			_transientGameDataService = transientGameDataService;
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
			_transientGameDataService.Data.ShopData.UsedWeaponTypes.Clear();
	}
}