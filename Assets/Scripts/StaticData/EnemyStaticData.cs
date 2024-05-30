using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "EnemyPrefab Static Data", menuName = "Scriptable Object/Static Data/EnemyPrefab")]
	public class EnemyStaticData : ScriptableObject
	{
		public float MovementSpeed;
		public int CurrentHealth;
		public int Damage;
	}
}