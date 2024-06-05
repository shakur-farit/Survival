using System.Collections.Generic;
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
				{ EnemyType.Medusa, 1},
				{ EnemyType.Orc, 1}
			};
		}

		private void Start()
		{
			_enemies = new List<EnemyType>();

			foreach (KeyValuePair<EnemyType, int> keyValuePair in _enemiesOnLevel)
			{
				for (int i = 0; i < keyValuePair.Value; i++) 
					_enemies.Add(keyValuePair.Key);
			}

			foreach (EnemyType enemyType in _enemies) 
				SpawnEnemy(enemyType);
		}

		private async void SpawnEnemy(EnemyType enemyType)
		{
			Vector2 randomPosition = new Vector2(_randomService.Next(-10f, 10f), _randomService.Next(10f, 10f));
			GameObject enemyObject =  await _enemyFactory.Create(randomPosition);

			if (enemyObject.TryGetComponent(out Enemy enemy))
				enemy.Initialize(enemyType);

			if (enemyObject.TryGetComponent(out EnemyAnimator animator)) 
				animator.StartMoving();
		}
	}
}
