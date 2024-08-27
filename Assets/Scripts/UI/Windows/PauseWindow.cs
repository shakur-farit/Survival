using Infrastructure.Services.Timer;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class PauseWindow : WindowBase
	{
		[SerializeField] private Button _settingsButton;
		[SerializeField] private Button _quitButton;

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
			_settingsButton.onClick.AddListener(OpenSettingsWindow);
			_quitButton.onClick.AddListener(QuitGame);
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.Pause);

		private void UnpauseGame() => 
			_pauseService.UnpauseGame();

		private void OpenSettingsWindow()
		{
			Debug.Log("OpenSettings");
		}

		private void QuitGame()
		{
			Debug.Log("Quit");
		}
	}
}