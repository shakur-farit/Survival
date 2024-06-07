using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using EnemyLogic;
using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Spawn
{
	public class Spawner : MonoBehaviour
	{
		private readonly Dictionary<EnemyType, int> _enemiesOnLevel = new();
		private List<EnemyType> _enemies;
		private int _numberOfWaves;

		private IRandomService _randomService;
		private IEnemyFactory _enemyFactory;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, IRandomService randomService, IStaticDataService staticData)
		{
			_enemyFactory = enemyFactory;
			_randomService = randomService;
			_staticDataService = staticData;
		}

		private void Awake()
		{
		//	foreach (LevelStaticData levelStaticData in _staticDataService.LevelsListStaticData.LevelsList)
		//	foreach (WavesOnLevelInfo wavesOnLevelInfo in levelStaticData.WavesOnLevel)
		//	foreach (EnemiesInWaveInfo enemiesInWaveInfo in wavesOnLevelInfo.EnemiesInWave)
		//		_enemiesOnLevel.Add(enemiesInWaveInfo.Type, enemiesInWaveInfo.Number);

			_numberOfWaves = _staticDataService.LevelsListStaticData.LevelsList[0].WavesOnLevel.Count;
		}

		private async void Start()
		{
			foreach (LevelStaticData levelStaticData in _staticDataService.LevelsListStaticData.LevelsList)
			{
				foreach (WavesOnLevelInfo wavesOnLevel in levelStaticData.WavesOnLevel)
				{
					foreach (EnemiesInWaveInfo enemiesInWaveInfo in wavesOnLevel.EnemiesInWave)
					{
						_enemiesOnLevel.Add(enemiesInWaveInfo.Type, enemiesInWaveInfo.Number);
					}
					SpawnWaveOfEnemies();
					_enemiesOnLevel.Clear();
					await UniTask.Delay(5000);
				}
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
