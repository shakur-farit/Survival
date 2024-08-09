using UI.Services.Windows;
using Zenject;

namespace UI.Windows
{
	public class InformationWindow : WindowBass
	{
		private IWindowsService _windowService;

		[Inject]
		public void Constructor(IWindowsService windowsService) => 
			_windowService = windowsService;

		protected override void OnAwake() => 
			ActionButton.onClick.AddListener(CloseWindow);

		private void CloseWindow() => 
			_windowService.Close(WindowType.Information);
	}
}