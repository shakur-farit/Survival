using UnityEngine;

namespace Assets.Scripts.StaticData
{
	[CreateAssetMenu(fileName = "Enemy Static Data", menuName = "Scriptable Object/Static Data/Enemy")]
	public class EnemyStaticData : ScriptableObject
	{
		public float MovementSpeed;
	}
}