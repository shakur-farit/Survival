using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Character Static Data", menuName = "Scriptable Object/Static Data/Character")]
	public class CharacterStaticData : ScriptableObject
	{
		public float MovementSpeed;
		public Sprite BodySprite;
		public Sprite HandSprite;
		public RuntimeAnimatorController Controller;
	}
}