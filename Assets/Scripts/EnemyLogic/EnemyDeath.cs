using Infrastructure.Services.Factories.Enemy;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyDeath : IEnemyDeath
	{
		private IEnemyFactory _enemyFactory;

		[Inject]
		public void Constructor(IEnemyFactory enemyFactory) => 
			_enemyFactory = enemyFactory;

		public void Die(GameObject gameObject) => 
			_enemyFactory.Destroy(gameObject);
	}
}