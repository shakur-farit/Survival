using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility;
using Zenject;

namespace Soundtrack
{
	public class MusicSource : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;

		private IMusicVolumeController _volumeController;
		private IMusicSwitcher _musicSwitcher;

		[Inject]
		public void Constructor(IMusicVolumeController volumeController, IMusicSwitcher musicSwitcher)
		{
			_volumeController = volumeController;
			_musicSwitcher = musicSwitcher;
		}

		private void Awake()
		{
			_musicSwitcher.MusicChanged += SwitchMusic;
			_volumeController.MusicVolumeChanged += UpdateVolume;

			UpdateVolume();
		}

		private void OnDestroy()
		{
			_musicSwitcher.MusicChanged -= SwitchMusic;
			_volumeController.MusicVolumeChanged -= UpdateVolume;
		}

		private void SwitchMusic()
		{
			FadeOut();

			_audioSource.clip = _musicSwitcher.CurrentMusic;
			_audioSource.Play();

			FadeIn();
		}

		private async void FadeOut()
		{
			float elapsedTime = 0f;
			float initialVolume = _audioSource.volume;

			while (elapsedTime < Constants.MusicFadeDuration)
			{
				_audioSource.volume = Mathf.Lerp(initialVolume, 0, elapsedTime / Constants.MusicFadeDuration);
				elapsedTime += Time.deltaTime;
				await UniTask.Yield();
			}

			_audioSource.volume = 0;
		}

		private async void FadeIn()
		{
			float elapsedTime = 0f;
			float initialVolume = _audioSource.volume;

			while (elapsedTime < Constants.MusicFadeDuration)
			{
				_audioSource.volume = Mathf.Lerp(0, initialVolume, elapsedTime / Constants.MusicFadeDuration);
				elapsedTime += Time.deltaTime;
				await UniTask.Yield();
			}

			_audioSource.volume = _volumeController.MusicVolume;
		}

		private void UpdateVolume() => 
			_audioSource.volume = _volumeController.ScaledMusicVolume;
	}
}