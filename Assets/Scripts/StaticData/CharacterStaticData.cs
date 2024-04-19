using Character;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Character")]
	public class CharacterStaticData : ScriptableObject
	{
		public CharacterType CharacterType;
		public float MovementSpeed;
		public Sprite HandSprite;
		public RuntimeAnimatorController Controller;
	}
}