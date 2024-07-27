using Character;
using UnityEngine;
using Weapon;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Character")]
	public class CharacterStaticData : ScriptableObject
	{
		public CharacterType CharacterType;
		public WeaponType DefaultWeapon;
		[Range(0f, 10f)] public float MovementSpeed;
		[Range(1, 100)] public int StartHealth;
		[Range(1, 100)] public int MaxHealth;
		[Range(0.05f, 30f)] public float EnemyDetectRange;
		[Tooltip("Time to can take next damage. Value in milliseconds")]
		[Range(0, 5000)] public int DamageTakingCooldown;

		public Sprite HandSprite;
		public RuntimeAnimatorController Controller;

		private void OnValidate()
		{
			if(MaxHealth < StartHealth) 
				MaxHealth = StartHealth;
		}
	}
}