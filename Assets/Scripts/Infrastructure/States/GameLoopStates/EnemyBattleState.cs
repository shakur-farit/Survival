using Infrastructure.Services.PersistentProgress;
using Infrastructure.States.GameLoopStates;
using Soundtrack;
using Spawn;
using StaticData;

namespace Infrastructure.States.GameStates
{
	internal class EnemyBattleState : IGameLoopState
	{
		private readonly IEnemySpawner _enemySpawner;
		private readonly IMusicSwitcher _musicSwitcher;
		private readonly IPersistentProgressService _persistentProgressService;

		public EnemyBattleState(IEnemySpawner enemySpawner, IMusicSwitcher musicSwitcher, 
			IPersistentProgressService persistentProgressService)
		{
			_enemySpawner = enemySpawner;
			_musicSwitcher = musicSwitcher;
			_persistentProgressService = persistentProgressService;
		}

		public void Enter()
		{
			SpawnEnemies();
			PlayEnemyBattleMusic();

		}

		public void Exit()
		{
		}

		private async void SpawnEnemies()
		{
			LevelStaticData levelStaticData = _persistentProgressService.Progress.LevelData.CurrentLevelStaticData;

			await _enemySpawner.Spawn(levelStaticData);
		}

		private void PlayEnemyBattleMusic() =>
			_musicSwitcher.PlayEnemyBattle();
	}
}