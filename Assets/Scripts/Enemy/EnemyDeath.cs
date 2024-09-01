using Cysharp.Threading.Tasks;
using Data;
using Enemy.Factory;
using Infrastructure.Services.PersistentProgress;
using LevelLogic;
using Spawn;
using UnityEngine;
using Zenject;

namespace Enemy
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

		public async UniTask Die(GameObject gameObject, Vector2 position)
		{
			EnemyData enemyData = _persistentProgressService.Progress.EnemyData;

			RemoveFromCharacterRange(gameObject, enemyData);
			AddToDeadEnemies(gameObject, enemyData);

			await SpawnDrop(position);

			Destroy(gameObject);

			TryCompleteLevel();
		}

		private static void RemoveFromCharacterRange(GameObject gameObject, EnemyData enemyData) => 
			enemyData.EnemiesInRangeList.Remove(gameObject);

		private static void AddToDeadEnemies(GameObject gameObject, EnemyData enemyData) => 
			enemyData.DeadEnemies.Add(gameObject);

		private async UniTask SpawnDrop(Vector2 position) => 
			await _dropSpawner.Spawn(position);

		private void Destroy(GameObject gameObject) => 
			_enemyFactory.Destroy(gameObject);

		private void TryCompleteLevel() => 
			_levelCompleter.TryCompleteLevel();
	}
}