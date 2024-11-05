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
		public int MusicVolume;
		public int SoundEffectsVolume;
	}
}