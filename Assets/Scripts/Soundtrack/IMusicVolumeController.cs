using System;

namespace Soundtrack
{
	public interface IMusicVolumeController
	{
		event Action MusicVolumeChanged;
		int MusicVolume { get; }
		float ScaledMusicVolume { get; }
		
		void AddMusicVolume();
		void RemoveMusicVolume();
	}
}