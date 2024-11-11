using Infrastructure.Services.PersistentProgress;
using Sounds;
using UnityEngine;
using Zenject;

namespace Effects.SoundEffects.Shoot
{
	public class ReloadSoundEffect : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;

		private IPersistentProgressService _persistentProgressService;
		private IVolumeController _volumeController;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IVolumeController volumeController)
		{
			_persistentProgressService = persistentProgressService;
			_volumeController = volumeController;
		}

		private void Awake() =>
			_volumeController.SoundEffectsVolumeChanged += UpdateVolume;

		private void OnDestroy() =>
			_volumeController.SoundEffectsVolumeChanged -= UpdateVolume;

		private void OnEnable() =>
			_audioSource.clip = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.ReloadSoundEffect;

		private void UpdateVolume() =>
			_audioSource.volume = _volumeController.GetScaledSoundEffectsVolume();
	}
}