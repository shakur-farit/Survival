using Enemy;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Enemy Static Data", menuName = "Scriptable Object/Static Data/Enemy")]
	public class EnemyStaticData : ScriptableObject
	{
		public EnemyType Type;
		public Sprite Sprite;
		public RuntimeAnimatorController Animator;
		public TileBase TileToMovement;
		public TileBase TileToSpawn;
		[Range(0f, 10f)] public float MovementSpeed;
		[Range(1, 100)] public int CurrentHealth;
		[Range(0, 10)] public int Damage;
	}
}