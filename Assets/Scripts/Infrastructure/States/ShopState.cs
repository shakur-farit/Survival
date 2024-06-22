using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.States
{
	public class ShopState : IGameState
	{
		private readonly IWindowsService _windowsService;

		public ShopState(IWindowsService windowsService) => 
			_windowsService = windowsService;

		public void Enter() => 
			_windowsService.Open(WindowType.Shop);

		public void Exit() => 
			_windowsService.Close(WindowType.Shop);
	}
}