using Effects.SoundEffects.Shot;
using Infrastructure.Services.PauseService;
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
		private IClickSoundEffectFactory _clickSoundEffectFactory;

		[Inject]
		public void Constructor(IWindowsService windowsService, IPauseService pauseService, 
			IClickSoundEffectFactory clickSoundEffectFactory)
		{
			_windowsService = windowsService;
			_pauseService = pauseService;
			_clickSoundEffectFactory = clickSoundEffectFactory;
		}

		protected override void OnAwake()
		{
			base.OnAwake();

			CloseButton.onClick.AddListener(UnpauseGame);
			CloseButton.onClick.AddListener(MakeClickSound);
			_settingsButton.onClick.AddListener(OpenSettingsWindow);
			_settingsButton.onClick.AddListener(MakeClickSound);
			_quitButton.onClick.AddListener(QuitGame);
			_quitButton.onClick.AddListener(MakeClickSound);
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.Pause);

		private void UnpauseGame() => 
			_pauseService.UnpauseGame();

		private void OpenSettingsWindow() => 
			_windowsService.Open(WindowType.Settings);

		private void QuitGame()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
		}

		private void MakeClickSound() =>
			_clickSoundEffectFactory.Create();

	}
}