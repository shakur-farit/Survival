using Cysharp.Threading.Tasks;
using UI.Factory;
using UI.Windows;
using UnityEngine;

namespace UI.Services.Windows
{
	public class WindowsService : IWindowsService
	{
		private readonly IUIFactory _uiFactory;

		public WindowsService(IUIFactory uiFactory) => 
			_uiFactory = uiFactory;

		public async UniTask Open(WindowType type)
		{
			switch (type)
			{
				case WindowType.MainMenu:
					await _uiFactory.CreateMainMenuWindow();
					break;
				case WindowType.LevelComplete:
					await _uiFactory.CreateLevelCompleteWindow();
					break;
				case WindowType.GameOver:
					await _uiFactory.CreateGameOverWindow();
					break;
				case WindowType.WeaponStats:
					await _uiFactory.CreateWeaponStatsWindow();
					break;
				case WindowType.Information:
					await _uiFactory.CreateInformationWindow();
					break;
				case WindowType.Dialog:
					await _uiFactory.CreateDialogWindow();
					break;
				case WindowType.Pause:
					await _uiFactory.CreatePauseWindow();
					break;
			}
		}

		public void Close(WindowType type)
		{
			switch (type)
			{
				case WindowType.MainMenu:
					_uiFactory.DestroyMainMenuWindow();
					break;
				case WindowType.LevelComplete:
					_uiFactory.DestroyLevelCompleteWindow();
					break;
				case WindowType.GameOver:
					_uiFactory.DestroyGameOverWindow();
					break;
				case WindowType.WeaponStats:
					_uiFactory.DestroyWeaponStatsWindow();
					break;
				case WindowType.Information:
					_uiFactory.DestroyInformationWindow();
					break;
				case WindowType.Dialog:
					_uiFactory.DestroyDialogWindow();
					break;
				case WindowType.Pause:
					_uiFactory.DestroyPauseWindow();
					break;
			}
		}
	}
}
