using Assets.Scripts.Infrastructure.Services.Factory;
using Assets.Scripts.Infrastructure.Services.Randomizer;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Spawn
{
	public class Spawner : MonoBehaviour
	{
		private RandomService _randomService;
		private GameFactory _gameFactory;

		[Inject]
		public void Constructor(GameFactory gameFactory, RandomService randomService)
		{
			_gameFactory = gameFactory;
			_randomService = randomService;
		}

		private void Start() => 
			SpawnEnemy();

		private async void SpawnEnemy()
		{
			Vector2 randomPosition = new Vector2(_randomService.Next(-10f, 10f), _randomService.Next(10f, 10f));

			await _gameFactory.CreateEnemy(randomPosition);
		}
	}
}
