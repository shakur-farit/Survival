using UnityEngine;

namespace EnemyLogic
{
	public interface IEnemyDeath
	{
		void Die(GameObject gameObject, Vector2 transform);
	}
}