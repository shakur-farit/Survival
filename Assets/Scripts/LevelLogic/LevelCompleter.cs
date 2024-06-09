using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using UnityEngine;

namespace LevelLogic
{
	public class LevelCompleter : ILevelCompleter
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IPersistentProgressService _persistentProgressService;

		public LevelCompleter(IGameStatesSwitcher gameStatesSwitcher,
			IPersistentProgressService persistentProgressService)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
			_persistentProgressService = persistentProgressService;
		}

		public void TryCompleteLevel()
		{
			EnemyData enemyData = _persistentProgressService.Progress.EnemyData;
			int enemiesNumberInLevel = _persistentProgressService.Progress.LevelData.EnemiesNumberInLevele;

			if (enemiesNumberInLevel == enemyData.DeadEnemies.Count)
			{
				enemyData.DeadEnemies.Clear();
				_gameStatesSwitcher.SwitchState<LevelComplete>();
			}
		}
	}
}