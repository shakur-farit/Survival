using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Timer;
using Infrastructure.States;
using Infrastructure.States.GameLoopStates.StatesMachine;
using Infrastructure.States.GameStates;
using Infrastructure.States.GameStates.StatesMachine;
using Soundtrack;
using Utility;

namespace LevelLogic
{
	public class LevelCompleter : ILevelCompleter
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly ICountDownTimer _timer;
		private readonly IMusicSwitcher _musicSwitcher;
		private readonly ILevelLoopStatesSwitcher _levelLoopStatesSwitcher;

		public LevelCompleter(IGameStatesSwitcher gameStatesSwitcher,
			IPersistentProgressService persistentProgressService, ICountDownTimer timer, 
			IMusicSwitcher musicSwitcher, ILevelLoopStatesSwitcher levelLoopStatesSwitcher)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
			_persistentProgressService = persistentProgressService;
			_timer = timer;
			_musicSwitcher = musicSwitcher;
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