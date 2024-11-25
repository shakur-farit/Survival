using Soundtrack;
using UnityEngine;
using Zenject;

namespace Effects.SoundEffects.Shot
{
	public class TakeDamageSoundEffect : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;

		private ISoundEffectsVolumeController _volumeController;

		[Inject]
		public void Constructor(ISoundEffectsVolumeController volumeController) =>
			_volumeController = volumeController;

		private void OnEnable() =>
			UpdateVolume();

		private void UpdateVolume() =>
			_audioSource.volume = _volumeController.ScaledSoundEffectsVolume;

	}
}