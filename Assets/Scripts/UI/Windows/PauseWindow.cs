using Infrastructure.Services.Timer;
using UI.Services.Windows;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
	public class PauseWindow : WindowBase
	{
		private IWindowsService _windowsService;
		private IPauseService _pauseService;

		[Inject]
		public void Constructor(IWindowsService windowsService, IPauseService pauseService)
		{
			_windowsService = windowsService;
			_pauseService = pauseService;
		}

		protected override void OnAwake()
		{
			base.OnAwake();

			CloseButton.onClick.AddListener(UnpauseGame);
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.Pause);

		private void UnpauseGame()
		{
			Debug.Log("Unp");

			_pauseService.UnpauseGame();
		}
	}
}