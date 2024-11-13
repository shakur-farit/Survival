using Soundtrack;
using TMPro;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class SettingsWindow : WindowBase
	{
		[SerializeField] private Button _addSoundEffectVolumeButton;
		[SerializeField] private Button _removeSoundEffectVolumeButton;
		[SerializeField] private Button _addMusicVolumeButton;
		[SerializeField] private Button _removeMusicVolumeButton;
		[SerializeField] private TextMeshProUGUI _soundEffectsVolumeText;
		[SerializeField] private TextMeshProUGUI _musicVolumeText;

		private IWindowsService _windowsService;
		private ISoundEffectsVolumeController _soundEffectsVolumeController;
		private IMusicVolumeController _musicVolumeController;

		[Inject]
		public void Constructor(IWindowsService windowsService, ISoundEffectsVolumeController soundEffectsVolumeController,
			IMusicVolumeController musicVolumeController)
		{
			_windowsService = windowsService;
			_soundEffectsVolumeController = soundEffectsVolumeController;
			_musicVolumeController = musicVolumeController;

		}

		private void OnEnable()
		{
			_soundEffectsVolumeController.SoundEffectsVolumeChanged += UpdateSoundEffectsVolumeText;
			_musicVolumeController.MusicVolumeChanged += UpdateMusicVolumeText;
		}

		private void OnDisable()
		{
			_soundEffectsVolumeController.SoundEffectsVolumeChanged -= UpdateSoundEffectsVolumeText;
			_musicVolumeController.MusicVolumeChanged -= UpdateMusicVolumeText;
		}

		protected override void OnAwake()
		{
			base.OnAwake();

			UpdateSoundEffectsVolumeText();
			UpdateMusicVolumeText();

			_addSoundEffectVolumeButton.onClick.AddListener(AddSoundEffectsVolume);
			_removeSoundEffectVolumeButton.onClick.AddListener(RemoveSoundEffectsVolume);

			_addMusicVolumeButton.onClick.AddListener(AddSMusicVolume);
			_removeMusicVolumeButton.onClick.AddListener(RemoveMusicVolume);
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.Settings);

		private void AddSoundEffectsVolume() => 
			_soundEffectsVolumeController.AddSoundEffectsVolume();

		private void RemoveSoundEffectsVolume() => 
			_soundEffectsVolumeController.RemoveSoundEffectsVolume();

		private void AddSMusicVolume() =>
			_musicVolumeController.AddMusicVolume();

		private void RemoveMusicVolume() =>
			_musicVolumeController.RemoveMusicVolume();

		private void UpdateSoundEffectsVolumeText() => 
			_soundEffectsVolumeText.text = _soundEffectsVolumeController.SoundEffectsVolume.ToString();

		private void UpdateMusicVolumeText() => 
			_musicVolumeText.text = _musicVolumeController.MusicVolume.ToString();
	}
}