using Data;
using Data.Transient;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using Infrastructure.States.GameStates;
using Infrastructure.States.LevelLoopStates;
using Infrastructure.States.LevelLoopStates.StatesMachine;

namespace LevelLogic
{
	public class LevelCompleter : ILevelCompleter
	{
		private readonly ITransientGameDataService _transientGameDataService;
		private readonly ILevelLoopStatesSwitcher _levelLoopStatesSwitcher;

		public LevelCompleter(ITransientGameDataService transientGameDataService,  ILevelLoopStatesSwitcher levelLoopStatesSwitcher)
		{
			_transientGameDataService = transientGameDataService;
			_levelLoopStatesSwitcher = levelLoopStatesSwitcher;
		}

		public void TryCompleteLevel()
		{
			EnemyData enemyData = _transientGameDataService.Data.EnemyData;
			int enemiesNumberInLevel = _transientGameDataService.Data.LevelData.EnemiesNumberInLevele;

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