using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Hero")]
	public class HeroStaticData : ScriptableObject
	{
		public float MovementSpeed;
		public Sprite BodySprite;
		public Sprite HandSprite;
		public RuntimeAnimatorController Controller;
	}
}