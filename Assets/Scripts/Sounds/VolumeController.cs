using System;
using Infrastructure.Services.StaticData;
using Utility;

namespace Sounds
{
	public class VolumeController : IVolumeController
	{
		public event Action SoundEffectsVolumeChanged;
		public event Action MusicVolumeChanged;

		private int _soundEffectsVolume;
		private bool _isScaled;

		private readonly IStaticDataService _staticDataService;

		public VolumeController(IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;

			_soundEffectsVolume = _staticDataService.SoundsStaticData.CurrentSoundEffectsVolume;
		}

		public float GetScaledSoundEffectsVolume()
		{
			int currentSoundEffectsVolume = _staticDataService.SoundsStaticData.CurrentSoundEffectsVolume;
			int maxSoundEffectsVolume = _staticDataService.SoundsStaticData.MaxSoundEffectsVolume;
			
			_isScaled = true;

			return _soundEffectsVolume = currentSoundEffectsVolume / maxSoundEffectsVolume;
		}

		public int GetNonScaledSoundEffectsVolume()
		{
			if (_isScaled == false)
				return _soundEffectsVolume;

			int maxSoundEffectsVolume = _staticDataService.SoundsStaticData.MaxSoundEffectsVolume;
			int currentSoundEffectsVolume = _staticDataService.SoundsStaticData.CurrentSoundEffectsVolume;

			_soundEffectsVolume *= maxSoundEffectsVolume;

			_isScaled = false;

			if (_soundEffectsVolume > maxSoundEffectsVolume)
				return currentSoundEffectsVolume;

			return _soundEffectsVolume;
		}

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
