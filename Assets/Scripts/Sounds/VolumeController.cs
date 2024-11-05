using System;
using Infrastructure.Services.StaticData;
using Utility;

namespace Sounds
{
	public class VolumeController
	{
		public event Action SoundEffetcsVolumeChanged;
		public event Action MusicVolumeChanged;

		public int SoundEffectsVolume { get; private set; }

		private readonly IStaticDataService _staticDataService;

		public VolumeController(IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;


			InitializeVolume();
		}

		private void InitializeVolume()
		{
			int currentSoundEffectsVolume = _staticDataService.SoundsStaticData.CurrentSoundEffectsVolume;
			int maxSoundEffectsVolume = _staticDataService.SoundsStaticData.MaxSoundEffectsVolume;

			SoundEffectsVolume = currentSoundEffectsVolume / maxSoundEffectsVolume;
		}

		private void AddSoundEffectsVolume()
		{
			SoundEffectsVolume += Constants.VolumeStep;

			int maxSoundEffectsVolume = _staticDataService.SoundsStaticData.MaxSoundEffectsVolume;

			if(SoundEffectsVolume >= maxSoundEffectsVolume)
				SoundEffectsVolume = maxSoundEffectsVolume;

			SoundEffetcsVolumeChanged?.Invoke();
		}

		private void RemoveSoundEffectsVolume()
		{
			SoundEffectsVolume -= Constants.VolumeStep;

			if (SoundEffectsVolume <= 0)
				SoundEffectsVolume = 0;

			SoundEffetcsVolumeChanged?.Invoke();
		}
	}
}
