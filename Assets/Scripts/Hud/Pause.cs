using Effects.SoundEffects.Click.Factory;
using Effects.SoundEffects.Shot;
using Infrastructure.Services.PauseService;
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
		private IClickSoundEffectFactory _clickSoundEffectFactory;

		[Inject]
		public void Constructor(IPauseService pauseService, IWindowsService windowsService, IClickSoundEffectFactory clickSoundEffectFactory)
		{
			_pauseService = pauseService;
			_windowsService = windowsService;
			_clickSoundEffectFactory = clickSoundEffectFactory;
		}

		private void Awake()
		{
			_pauseButton.onClick.AddListener(PauseGame);
			_pauseButton.onClick.AddListener(OpenPauseWindow);
			_pauseButton.onClick.AddListener(MakeClickSound);
		}

		private async void OpenPauseWindow() => 
			await _windowsService.Open(WindowType.Pause);

		private void PauseGame() => 
			_pauseService.PauseGame();

		private void MakeClickSound() => 
			_clickSoundEffectFactory.Create();
	}
}