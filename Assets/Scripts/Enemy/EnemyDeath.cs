using Infrastructure.Services.Factories.Enemy;
using UnityEngine;

namespace Enemy
{
	public class EnemyDeath : IEnemyDeath
	{
		private IEnemyFactory _enemyFactory;

		public void Constructor(IEnemyFactory enemyFactory) => 
			_enemyFactory = enemyFactory;

		public void Die() => 
			_enemyFactory.Destroy();
	}
}