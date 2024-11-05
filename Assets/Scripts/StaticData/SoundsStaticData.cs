using UnityEngine;
using UnityEngine.Audio;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Sound")]
	public class SoundsStaticData : ScriptableObject
	{
		public AudioMixerGroup MasterMixerGroup;
		public AudioMixerSnapshot OnFullSnapshot;
		public AudioMixerSnapshot LowSnapshot;
		[Range(0, 10)] public int MaxMusicVolume;
		[Range(0, 10)] public int MaxSoundEffectsVolume;
		[Range(0, 10)] public int CurrentMusicVolume;
		[Range(0, 10)] public int CurrentSoundEffectsVolume;
	}
}