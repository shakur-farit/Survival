using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using Soundtrack;
using UnityEngine;
using Zenject;

namespace Effects.SoundEffects.Shot
{
	public class ShotSoundEffect : MonoBehaviour
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

		private void OnEnable()
		{
			InitClip();
			UpdateVolume();
		}

		private void InitClip() => 
			_audioSource.clip = _transientGameDataService.Data.CharacterData.WeaponData.CurrentWeapon.ShotSoundEffect;

		private void UpdateVolume() => 
			_audioSource.volume = _volumeController.ScaledSoundEffectsVolume;
	}
}