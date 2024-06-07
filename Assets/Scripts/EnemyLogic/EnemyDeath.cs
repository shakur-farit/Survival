using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyDeath : IEnemyDeath
	{
		private IEnemyFactory _enemyFactory;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, IPersistentProgressService persistentProgressService)
		{
			_enemyFactory = enemyFactory;
			_persistentProgressService = persistentProgressService;
		}

		public void Die(GameObject gameObject)
		{
			_persistentProgressService.Progress.EnemyData.EnemiesInRangeList.Remove(gameObject);
			_enemyFactory.Destroy(gameObject);
		}
	}
}