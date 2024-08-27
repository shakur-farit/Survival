using UI.Services.Windows;
using Zenject;

namespace UI.Windows
{
	public class SettingsWindow : WindowBase
	{
		private IWindowsService _windowsService;

		[Inject]
		public void Constructor(IWindowsService windowsService) => 
			_windowsService = windowsService;

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.Settings);
	}
}