using System;

namespace Sounds
{
	public interface IVolumeController
	{
		event Action SoundEffectsVolumeChanged;
		event Action MusicVolumeChanged;
		float GetScaledSoundEffectsVolume();
		int GetNonScaledSoundEffectsVolume();
		void AddSoundEffectsVolume();
		void RemoveSoundEffectsVolume();
	}
}