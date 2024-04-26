using Assets.Scripts.Character;
using Assets.Scripts.Weapon;
using UnityEngine;

namespace Assets.Scripts.StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Character")]
	public class CharacterStaticData : ScriptableObject
	{
		public CharacterType CharacterType;
		public WeaponType DefaultWeapon;
		public float MovementSpeed;
		public Sprite HandSprite;
		public RuntimeAnimatorController Controller;
	}
}