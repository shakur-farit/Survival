using Coin;
using Data.Transient;
using Enemy.Factory;
using Infrastructure.Services.TransientGameData;
using LevelLogic;
using Spawn;
using StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyDeath : IEnemyDeath
	{
		private IEnemyFactory _enemyFactory;
		private ITransientGameDataService _transientGameDataService;
		private ILevelCompleter _levelCompleter;
		private IDropSpawner _dropSpawner;
		private IScoreCounter _scoreCounter;


		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, ITransientGameDataService transientGameDataService, 
			ILevelCompleter levelCompleter, IDropSpawner dropSpawner, IScoreCounter scoreCounter)
		{
			_enemyFactory = enemyFactory;
			_transientGameDataService = transientGameDataService;
			_levelCompleter = levelCompleter;
			_dropSpawner = dropSpawner;
			_scoreCounter = scoreCounter;
		}

		public void Die(GameObject gameObject, Vector2 position, EnemyStaticData enemyStaticData)
		{
			EnemyData enemyData = _transientGameDataService.Data.EnemyData;

			RemoveFromCharacterRange(gameObject, enemyData);
			AddToDeadEnemies(gameObject, enemyData);

			AddScore(enemyStaticData);

			SpawnDrop(position);

			Destroy(gameObject);

			TryCompleteLevel();
		}

		private static void RemoveFromCharacterRange(GameObject gameObject, EnemyData enemyData) => 
			enemyData.EnemiesInRangeList.Remove(gameObject);

		private static void AddToDeadEnemies(GameObject gameObject, EnemyData enemyData) => 
			enemyData.DeadEnemies.Add(gameObject);

		private void SpawnDrop(Vector2 position) => 
			_dropSpawner.Spawn(position);

		private void AddScore(EnemyStaticData enemyData) => 
			_scoreCounter.AddScore(enemyData.ScoreAmount);

		private void Destroy(GameObject gameObject) => 
			_enemyFactory.Destroy(gameObject);

		private void TryCompleteLevel() => 
			_levelCompleter.TryCompleteLevel();
	}
}