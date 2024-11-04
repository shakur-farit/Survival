using UnityEngine;
using UnityEngine.Audio;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Music")]
	public class MusicStaticData : ScriptableObject
	{
		public AudioMixerGroup MasterMixerGroup;
		public AudioMixerSnapshot OnFullSnapshot;
		public AudioMixerSnapshot LowSnapshot;
		public int Volume;
	}
}