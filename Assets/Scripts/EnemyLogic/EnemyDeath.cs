using Data;
using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.PersistentProgress;
using LevelLogic;
using Spawn;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyDeath : IEnemyDeath
	{
		private IEnemyFactory _enemyFactory;
		private IPersistentProgressService _persistentProgressService;
		private ILevelCompleter _levelCompleter;
		private IDropSpawner _dropSpawner;


		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, IPersistentProgressService persistentProgressService, 
			ILevelCompleter levelCompleter, IDropSpawner dropSpawner)
		{
			_enemyFactory = enemyFactory;
			_persistentProgressService = persistentProgressService;
			_levelCompleter = levelCompleter;
			_dropSpawner = dropSpawner;
		}

		public void Die(GameObject gameObject, Vector2 position)
		{
			EnemyData enemyData = _persistentProgressService.Progress.EnemyData;

			enemyData.EnemiesInRangeList.Remove(gameObject);
			enemyData.DeadEnemies.Add(gameObject);

			_dropSpawner.Spawn(position);

			_enemyFactory.Destroy(gameObject);

			_levelCompleter.TryCompleteLevel();
		}
	}
}