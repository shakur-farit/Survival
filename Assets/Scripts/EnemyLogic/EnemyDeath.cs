using Data;
using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using StaticData;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyDeath : IEnemyDeath
	{
		private IEnemyFactory _enemyFactory;
		private IPersistentProgressService _persistentProgressService;
		private IEnemiesCounter _counter;
		private IGameStatesSwitcher _gameStatesSwitcher;


		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, IPersistentProgressService persistentProgressService,
			IEnemiesCounter counter, IGameStatesSwitcher gameStatesSwitcher)
		{
			_enemyFactory = enemyFactory;
			_persistentProgressService = persistentProgressService;
			_counter = counter;
			_gameStatesSwitcher = gameStatesSwitcher;
		}

		public void Die(GameObject gameObject)
		{
			EnemyData enemyData = _persistentProgressService.Progress.EnemyData;

			int enemiesOnLevel = _counter.GetCountEnemies();

			enemyData.EnemiesInRangeList.Remove(gameObject);
			enemyData.DeadEnemies.Add(gameObject);

			Debug.Log($"{enemyData.DeadEnemies.Count} / {enemiesOnLevel}");

			if (enemiesOnLevel == enemyData.DeadEnemies.Count)
			{
				Debug.Log("Complete");
				_gameStatesSwitcher.SwitchState<LevelComplete>();
			}

			_enemyFactory.Destroy(gameObject);
		}
	}
}