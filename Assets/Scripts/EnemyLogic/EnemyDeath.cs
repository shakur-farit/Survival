using Data;
using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.PersistentProgress;
using LevelLogic;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyDeath : IEnemyDeath
	{
		private IEnemyFactory _enemyFactory;
		private IPersistentProgressService _persistentProgressService;
		private ILevelCompleter _levelCompleter;


		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, IPersistentProgressService persistentProgressService, 
			ILevelCompleter levelCompleter)
		{
			_enemyFactory = enemyFactory;
			_persistentProgressService = persistentProgressService;
			_levelCompleter = levelCompleter;
		}

		public void Die(GameObject gameObject)
		{
			EnemyData enemyData = _persistentProgressService.Progress.EnemyData;

			enemyData.EnemiesInRangeList.Remove(gameObject);
			enemyData.DeadEnemies.Add(gameObject);

			_enemyFactory.Destroy(gameObject);

			_levelCompleter.TryCompleteLevel();
		}
	}
}