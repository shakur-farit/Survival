using Infrastructure.Services.PersistentProgress;
using Soundtrack;
using UnityEngine;
using Zenject;

namespace Effects.SoundEffects.Reload
{
	public class ReloadSoundEffect : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;

		private IPersistentProgressService _persistentProgressService;
		private ISoundEffectsVolumeController _volumeController;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, ISoundEffectsVolumeController volumeController)
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
			_audioSource.volume = _volumeController.ScaledSoundEffectsVolume;
	}
}