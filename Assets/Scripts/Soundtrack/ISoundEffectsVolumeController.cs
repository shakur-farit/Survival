using System;

namespace Soundtrack
{
	public interface ISoundEffectsVolumeController
	{
		event Action SoundEffectsVolumeChanged;
		int SoundEffectsVolume { get; }
		float ScaledSoundEffectsVolume { get; }

		void AddSoundEffectsVolume();
		void RemoveSoundEffectsVolume();
	}
}