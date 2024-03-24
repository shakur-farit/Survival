using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Hero Static Data", menuName = "Scriptable Object/Static Data/Hero")]
	public class HeroStaticData : ScriptableObject
	{
		public float MovementSpeed;
	}
}