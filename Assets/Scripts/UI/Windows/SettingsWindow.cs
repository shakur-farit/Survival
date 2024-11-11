using System;
using Sounds;
using TMPro;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Debug = UnityEngine.Debug;

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
		private IVolumeController _volumeController;

		[Inject]
		public void Constructor(IWindowsService windowsService, IVolumeController volumeController)
		{
			_windowsService = windowsService;
			_volumeController = volumeController;
		}

		private void OnEnable() => 
			_volumeController.SoundEffectsVolumeChanged += UpdateSoundEffectsVolumeText;

		private void OnDisable() => 
			_volumeController.SoundEffectsVolumeChanged -= UpdateSoundEffectsVolumeText;

		protected override void OnAwake()
		{
			base.OnAwake();

			UpdateSoundEffectsVolumeText();

			_addSoundEffectVolumeButton.onClick.AddListener(AddSoundEffectsVolume);
			_removeSoundEffectVolumeButton.onClick.AddListener(RemoveSoundEffectsVolume);
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.Settings);

		private void AddSoundEffectsVolume() => 
			_volumeController.AddSoundEffectsVolume();

		private void RemoveSoundEffectsVolume() => 
			_volumeController.RemoveSoundEffectsVolume();

		private void UpdateSoundEffectsVolumeText() => 
			_soundEffectsVolumeText.text = _volumeController.GetNonScaledSoundEffectsVolume().ToString();
	}
}