using UI.Services.Windows;
using Zenject;

namespace UI.Windows
{
	public class InformationWindow : WindowBase
	{
		private IWindowsService _windowService;

		[Inject]
		public void Constructor(IWindowsService windowsService) => 
			_windowService = windowsService;

		protected override void CloseWindow() => 
			_windowService.Close(WindowType.Information);
	}
}