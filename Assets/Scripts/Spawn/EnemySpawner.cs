using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Enemy;
using Enemy.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using StaticData;
using UnityEngine;

namespace Spawn
{
	public class EnemySpawner : IEnemySpawner
	{
		private readonly Dictionary<EnemyType, int> _enemiesOnLevel = new();
		private List<EnemyType> _enemies = new();
		private bool _canSpawn;

		private readonly IRandomService _randomService;
		private readonly IEnemyFactory _enemyFactory;
		private readonly IPersistentProgressService _persistentProgressService;

		public EnemySpawner(IRandomService randomService, IEnemyFactory enemyFactory,
			IPersistentProgressService persistentProgressService)
		{
			_randomService = randomService;
			_enemyFactory = enemyFactory;
			_persistentProgressService = persistentProgressService;
		}

		public async UniTask Spawn(LevelStaticData levelStaticData)
		{
			_canSpawn = true;

			foreach (WavesOnLevelInfo wavesOnLevel in levelStaticData.WavesOnLevel)
			{
				_enemiesOnLevel.Clear();

				foreach (EnemiesInWaveInfo enemiesInWaveInfo in wavesOnLevel.EnemiesInWave)
					_enemiesOnLevel.Add(enemiesInWaveInfo.Type, enemiesInWaveInfo.Number);

				if (_canSpawn == false)
					return;

				SpawnWaveOfEnemies();

				await UniTask.Delay(levelStaticData.WaveCooldown);
			}
		}

		public void StopSpawn() => 
			_canSpawn = false;

		private void SpawnWaveOfEnemies()
		{
			_enemies = _enemiesOnLevel.SelectMany(kvp =>
				Enumerable.Repeat(kvp.Key, kvp.Value)).ToList();

			_enemies.ForEach(SpawnEnemy);
		}

		private void SpawnEnemy(EnemyType enemyType)
		{
			LevelStaticData levelStaticData = _persistentProgressService.Progress.LevelData.CurrentLevelStaticData;

			float minX = levelStaticData.MinEnemySpawnPosiotion.x;
			float maxX = levelStaticData.MaxEnemySpawnPosiotion.x;
			float minY = levelStaticData.MinEnemySpawnPosiotion.y;
			float maxY = levelStaticData.MaxEnemySpawnPosiotion.y;

			Vector2 randomPosition = new Vector2(_randomService.Next(minX, maxX), _randomService.Next(minY, maxY));
			GameObject enemyObject = _enemyFactory.Create(randomPosition);

			if (enemyObject.TryGetComponent(out EnemyInitializer enemy))
				enemy.Initialize(enemyType);

			if (enemyObject.TryGetComponent(out EnemyAnimator animator))
				animator.StartMoving();
		}
	}
}