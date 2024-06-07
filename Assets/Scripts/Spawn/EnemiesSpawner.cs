using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using EnemyLogic;
using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;

namespace Spawn
{
	public class EnemiesSpawner : IEnemiesSpawner
	{
		private readonly Dictionary<EnemyType, int> _enemiesOnLevel = new();
		private List<EnemyType> _enemies;

		private readonly IRandomService _randomService;
		private readonly IEnemyFactory _enemyFactory;
		private readonly IStaticDataService _staticDataService;

		public EnemiesSpawner(IRandomService randomService, IEnemyFactory enemyFactory, IStaticDataService staticDataService)
		{
			_randomService = randomService;
			_enemyFactory = enemyFactory;
			_staticDataService = staticDataService;
		}

		public async UniTask SpawnEnemies(LevelStaticData levelStaticData)
		{
			foreach (WavesOnLevelInfo wavesOnLevel in levelStaticData.WavesOnLevel)
			{
				foreach (EnemiesInWaveInfo enemiesInWaveInfo in wavesOnLevel.EnemiesInWave)
					_enemiesOnLevel.Add(enemiesInWaveInfo.Type, enemiesInWaveInfo.Number);

				SpawnWaveOfEnemies();
				_enemiesOnLevel.Clear();
				await UniTask.Delay(levelStaticData.WaveCooldown);
			}
		}

		private void SpawnWaveOfEnemies()
		{
			_enemies = _enemiesOnLevel.SelectMany(kvp =>
				Enumerable.Repeat(kvp.Key, kvp.Value)).ToList();

			_enemies.ForEach(SpawnEnemy);
		}

		private async void SpawnEnemy(EnemyType enemyType)
		{
			Vector2 randomPosition = new Vector2(_randomService.Next(-10f, 10f), _randomService.Next(-10f, 10f));
			GameObject enemyObject =  await _enemyFactory.Create(randomPosition);

			if (enemyObject.TryGetComponent(out Enemy enemy))
				enemy.Initialize(enemyType);

			if (enemyObject.TryGetComponent(out EnemyAnimator animator)) 
				animator.StartMoving();
		}
	}
}
