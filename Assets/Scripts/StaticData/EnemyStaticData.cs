using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "EnemyPrefab Static Data", menuName = "Scriptable Object/Static Data/EnemyPrefab")]
	public class EnemyStaticData : ScriptableObject
	{
		public float MovementSpeed;
		public float CurrentHealth;
		public float MaxHealth;
		public int Damage;
	}
}