using Cysharp.Threading.Tasks;
using UI.Services.Factory;
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
				case WindowType.MainMenuWindow:
					await _uiFactory.CreateMainMenuWindow();
					break;
			}
		}

		public void Close(WindowType type)
		{
			switch (type)
			{
				case WindowType.MainMenuWindow:
					_uiFactory.DestroyMainMenuWindow();
					break;
			}
		}
	}
}
