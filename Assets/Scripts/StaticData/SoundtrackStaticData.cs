using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Sound")]
	public class SoundtrackStaticData : ScriptableObject
	{
		public AudioClip BossBattle;
		public AudioClip EnemyBattle;
		public AudioClip DungeonMelancholy;
		public AudioClip ClearedRoom;
		public AudioClip MainMenu;

		[Range(0, 10)] public int MaxMusicVolume;
		[Range(0, 10)] public int MaxSoundEffectsVolume;
		[Range(0, 10)] public int CurrentMusicVolume;
		[Range(0, 10)] public int CurrentSoundEffectsVolume;
	}
}