using UnityEngine;

namespace Enemy
{
	public interface IEnemyDeath
	{
		void Die(GameObject gameObject, Vector2 transform);
	}
}