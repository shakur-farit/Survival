using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.States.GameStates;
using Infrastructure.States.LevelLoopStates;
using Infrastructure.States.LevelLoopStates.StatesMachine;

namespace LevelLogic
{
	public class LevelCompleter : ILevelCompleter
	{
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly ILevelLoopStatesSwitcher _levelLoopStatesSwitcher;

		public LevelCompleter(IPersistentProgressService persistentProgressService,  ILevelLoopStatesSwitcher levelLoopStatesSwitcher)
		{
			_persistentProgressService = persistentProgressService;
			_levelLoopStatesSwitcher = levelLoopStatesSwitcher;
		}

		public void TryCompleteLevel()
		{
			EnemyData enemyData = _persistentProgressService.Progress.EnemyData;
			int enemiesNumberInLevel = _persistentProgressService.Progress.LevelData.EnemiesNumberInLevele;

			if (enemiesNumberInLevel == enemyData.DeadEnemies.Count)
			{
				ClearDeadEnemiesList(enemyData);

				_levelLoopStatesSwitcher.SwitchState<LevelEndState>();
			}
		}

		private static void ClearDeadEnemiesList(EnemyData enemyData) => 
			enemyData.DeadEnemies.Clear();
	}
}