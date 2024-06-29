using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Special Effects")]
	public class SpecialEffectsStaticData : ScriptableObject
	{
		public Gradient ColorGradient;
		public float StartLifetime;
		public float StartSpeed;
		public float StartSize;
		public int MaxParticalNumber;
	}
}