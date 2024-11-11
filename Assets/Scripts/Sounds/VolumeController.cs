using System;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Utility;

namespace Sounds
{
	public class VolumeController : IVolumeController
	{
		public event Action SoundEffectsVolumeChanged;
		public event Action MusicVolumeChanged;

		private int _soundEffectsVolume;

		private readonly IStaticDataService _staticDataService;

		public VolumeController(IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;

			_soundEffectsVolume = _staticDataService.SoundsStaticData.CurrentSoundEffectsVolume;
		}

		public float GetScaledSoundEffectsVolume()
		{
			float maxSoundEffectsVolume = _staticDataService.SoundsStaticData.MaxSoundEffectsVolume;
			float currentSoundEffectsVolume = _soundEffectsVolume;

			return currentSoundEffectsVolume / maxSoundEffectsVolume;
		}

		public int GetNonScaledSoundEffectsVolume() => 
			_soundEffectsVolume;

		public void AddSoundEffectsVolume()
		{
			_soundEffectsVolume += Constants.VolumeStep;

			int maxSoundEffectsVolume = _staticDataService.SoundsStaticData.MaxSoundEffectsVolume;

			if(_soundEffectsVolume >= maxSoundEffectsVolume)
				_soundEffectsVolume = maxSoundEffectsVolume;

			SoundEffectsVolumeChanged?.Invoke();
		}

		public void RemoveSoundEffectsVolume()
		{

			_soundEffectsVolume -= Constants.VolumeStep;

			if (_soundEffectsVolume <= 0)
				_soundEffectsVolume = 0;

			SoundEffectsVolumeChanged?.Invoke();
		}
	}
}
