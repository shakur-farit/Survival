using Infrastructure.Services.PersistentProgress;
using Soundtrack;
using UnityEngine;
using Zenject;

namespace Effects.SoundEffects.Shot
{
	public class ShotSoundEffect : MonoBehaviour
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

		private void OnEnable()
		{
			InitClip();
			UpdateVolume();
		}

		private void InitClip() => 
			_audioSource.clip = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.ShotSoundEffect;

		private void UpdateVolume() => 
			_audioSource.volume = _volumeController.ScaledSoundEffectsVolume;
	}
}