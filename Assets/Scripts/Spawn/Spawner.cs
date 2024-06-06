using System.Collections.Generic;
using System.Linq;
using EnemyLogic;
using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.Randomizer;
using UnityEngine;
using Zenject;

namespace Spawn
{
	public class Spawner : MonoBehaviour
	{
		private IRandomService _randomService;
		private IEnemyFactory _enemyFactory;

		private Dictionary<EnemyType, int> _enemiesOnLevel;
		private List<EnemyType> _enemies;

		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, IRandomService randomService)
		{
			_enemyFactory = enemyFactory;
			_randomService = randomService;
		}

		private void Awake()
		{
			_enemiesOnLevel = new Dictionary<EnemyType, int>()
			{
				{ EnemyType.Hedusa, 3},
				{ EnemyType.Orc, 1}
			};
		}

		private void Start() => 
			SpawnWaveOfEnemies();

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
