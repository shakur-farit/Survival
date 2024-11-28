using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using Soundtrack;
using UnityEngine;
using Zenject;

namespace Effects.SoundEffects.Reload
{
	public class ReloadSoundEffect : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;

		private ITransientGameDataService _transientGameDataService;
		private ISoundEffectsVolumeController _volumeController;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService, ISoundEffectsVolumeController volumeController)
		{
			_transientGameDataService = transientGameDataService;
			_volumeController = volumeController;
		}

		private void Awake() =>
			_volumeController.SoundEffectsVolumeChanged += UpdateVolume;

		private void OnDestroy() =>
			_volumeController.SoundEffectsVolumeChanged -= UpdateVolume;

		private void OnEnable() =>
			_audioSource.clip = _transientGameDataService.Data.CharacterData.WeaponData.CurrentWeapon.ReloadSoundEffect;

		private void UpdateVolume() =>
			_audioSource.volume = _volumeController.ScaledSoundEffectsVolume;
	}
}