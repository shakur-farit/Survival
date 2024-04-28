using Character;
using UnityEngine;
using Weapon;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/CharacterPrefab")]
	public class CharacterStaticData : ScriptableObject
	{
		public CharacterType CharacterType;
		public WeaponType DefaultWeapon;
		public float MovementSpeed;
		public Sprite HandSprite;
		public RuntimeAnimatorController Controller;
	}
}