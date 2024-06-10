using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using EnemyLogic;
using Infrastructure.Services.Factories.Enemy;
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

		public EnemySpawner(IRandomService randomService, IEnemyFactory enemyFactory)
		{
			_randomService = randomService;
			_enemyFactory = enemyFactory;
		}

		public async UniTask SpawnEnemies(LevelStaticData levelStaticData)
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

		private async void SpawnEnemy(EnemyType enemyType)
		{
			Vector2 randomPosition = new Vector2(_randomService.Next(-10f, 10f), _randomService.Next(-10f, 10f));
			GameObject enemyObject = await _enemyFactory.Create(randomPosition);

			if (enemyObject.TryGetComponent(out Enemy enemy))
				enemy.Initialize(enemyType);

			if (enemyObject.TryGetComponent(out EnemyAnimator animator))
				animator.StartMoving();
		}
	}
}