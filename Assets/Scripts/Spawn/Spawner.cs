using Enemy.Factory;
using Infrastructure.Services.Randomizer;
using UnityEngine;
using Zenject;

namespace Spawn
{
	public class Spawner : MonoBehaviour
	{
		private IRandomService _randomService;
		private IEnemyFactory _enemyFactory;

		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, IRandomService randomService)
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
