using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Timer;
using Infrastructure.States;
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

		public LevelCompleter(IGameStatesSwitcher gameStatesSwitcher,
			IPersistentProgressService persistentProgressService, ICountDownTimer timer, IMusicSwitcher musicSwitcher)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
			_persistentProgressService = persistentProgressService;
			_timer = timer;
			_musicSwitcher = musicSwitcher;
		}

		public void TryCompleteLevel()
		{
			EnemyData enemyData = _persistentProgressService.Progress.EnemyData;
			int enemiesNumberInLevel = _persistentProgressService.Progress.LevelData.EnemiesNumberInLevele;

			if (enemiesNumberInLevel == enemyData.DeadEnemies.Count)
			{
				_timer.Completed += EnterToLevelCompleteState;

				ClearDeadEnemiesList(enemyData);

				StartTimer();
			}
		}

		private static void ClearDeadEnemiesList(EnemyData enemyData) => 
			enemyData.DeadEnemies.Clear();

		private void StartTimer()
		{
			_musicSwitcher.PlayClearedRoom();

			_timer.Start(_persistentProgressService.Progress.LevelData.CurrentLevelStaticData.TimeToCompleteLevel);
		}

		private void EnterToLevelCompleteState()
		{
			_timer.Completed -= EnterToLevelCompleteState;

			SetupNextLevel();

			_gameStatesSwitcher.SwitchState<LevelCompleteState>();
		}

		private void SetupNextLevel() => 
			_persistentProgressService.Progress.LevelData.PreviousLevel += Constants.NextLevelStep;
	}
}