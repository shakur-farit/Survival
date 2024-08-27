using Infrastructure.Services.Timer;
using UI.Services.Windows;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Hud
{
	public class Pause : MonoBehaviour
	{
		[SerializeField] private Button _pauseButton;

		private IPauseService _pauseService;
		private IWindowsService _windowsService;

		[Inject]
		public void Constructor(IPauseService pauseService, IWindowsService windowsService)
		{
			_pauseService = pauseService;
			_windowsService = windowsService;
		}

		private void Awake()
		{
			_pauseButton.onClick.AddListener(PauseGame);
			_pauseButton.onClick.AddListener(OpenPauseWindow);
		}

		private async void OpenPauseWindow() => 
			await _windowsService.Open(WindowType.Pause);

		private void PauseGame() => 
			_pauseService.PauseGame();
	}
}