using Assets.Scripts.UI.Services.Factory;
using Assets.Scripts.UI.Windows;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.UI.Services.Windows
{
	public class WindowsService
	{
		private readonly UIFactory _uiFactory;

		public WindowsService(UIFactory uiFactory) => 
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
