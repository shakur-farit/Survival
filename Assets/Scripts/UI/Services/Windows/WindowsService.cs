using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factories.UI;
using UI.Windows;

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
			}
		}
	}
}
