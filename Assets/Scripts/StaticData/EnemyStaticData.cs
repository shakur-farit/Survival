using EnemyLogic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Enemy Static Data", menuName = "Scriptable Object/Static Data/Enemy")]
	public class EnemyStaticData : ScriptableObject
	{
		public EnemyType Type;
		public Sprite Sprite;
		public RuntimeAnimatorController Animator;
		public float MovementSpeed;
		public int CurrentHealth;
		public int Damage;
	}
}