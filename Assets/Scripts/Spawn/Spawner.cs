using Character.Factory;
using Enemy;
using Infrastructure.Services.Randomizer;
using UnityEngine;
using Zenject;

namespace Spawn
{
	public class Spawner : MonoBehaviour
	{
		private RandomService _randomService;
		private EnemyFactory _enemyFactory;

		[Inject]
		public void Constructor(EnemyFactory enemyFactory, RandomService randomService)
		{
			_enemyFactory = enemyFactory;
			_randomService = randomService;
		}

		private void Start() => 
			SpawnEnemy();

		private async void SpawnEnemy()
		{
			Vector2 randomPosition = new Vector2(_randomService.Next(-10f, 10f), _randomService.Next(10f, 10f));

			await _enemyFactory.CreateEnemy(randomPosition);
		}
	}
}
