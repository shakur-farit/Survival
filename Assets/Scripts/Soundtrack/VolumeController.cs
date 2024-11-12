using System;
using Infrastructure.Services.StaticData;
using Utility;

namespace Soundtrack
{
	public class VolumeController : ISoundEffectsVolumeController, IMusicVolumeController
	{
		public event Action SoundEffectsVolumeChanged;
		public event Action MusicVolumeChanged;

		private float _maxSoundEffectsVolume;
		private float _maxMusicVolume;

		private readonly IStaticDataService _staticDataService;
		
		public int SoundEffectsVolume { get; private set; }
		public float ScaledSoundEffectsVolume => SoundEffectsVolume / _maxSoundEffectsVolume;

		public int MusicVolume { get; private set; }
		public float ScaledMusicVolume => MusicVolume / _maxMusicVolume;

		public VolumeController(IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;

			InitStartVolume();
		}

		public void AddSoundEffectsVolume()
		{
			SoundEffectsVolume += Constants.VolumeStep;

			if(SoundEffectsVolume >= _maxSoundEffectsVolume)
				SoundEffectsVolume = (int)_maxSoundEffectsVolume;

			SoundEffectsVolumeChanged?.Invoke();
		}

		public void RemoveSoundEffectsVolume()
		{

			SoundEffectsVolume -= Constants.VolumeStep;

			if (SoundEffectsVolume <= 0)
				SoundEffectsVolume = 0;

			SoundEffectsVolumeChanged?.Invoke();
		}

		public void AddMusicVolume()
		{
			MusicVolume += Constants.VolumeStep;

			if (MusicVolume >= _maxMusicVolume)
				MusicVolume = (int)_maxMusicVolume;

			MusicVolumeChanged?.Invoke();
		}

		public void RemoveMusicVolume()
		{
			MusicVolume -= Constants.VolumeStep;

			if (MusicVolume <= 0)
				MusicVolume = 0;

			MusicVolumeChanged?.Invoke();
		}

		private void InitStartVolume()
		{
			SoundEffectsVolume = _staticDataService.SoundtrackStaticData.CurrentSoundEffectsVolume;
			MusicVolume = _staticDataService.SoundtrackStaticData.CurrentMusicVolume;
			_maxSoundEffectsVolume = _staticDataService.SoundtrackStaticData.MaxSoundEffectsVolume;
			_maxMusicVolume = _staticDataService.SoundtrackStaticData.MaxMusicVolume;
		}
	}
}
