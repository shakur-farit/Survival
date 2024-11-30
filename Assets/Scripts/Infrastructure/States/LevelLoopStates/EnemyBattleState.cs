using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using Soundtrack;
using Spawn;
using StaticData;
using UnityEngine;

namespace Infrastructure.States.LevelLoopStates
{
	internal class EnemyBattleState : ILevelLoopState
	{
		private readonly IEnemySpawner _enemySpawner;
		private readonly IMusicSwitcher _musicSwitcher;
		private readonly ITransientGameDataService _transientGameDataService;

		public EnemyBattleState(IEnemySpawner enemySpawner, IMusicSwitcher musicSwitcher,
			ITransientGameDataService transientGameDataService)
		{
			_enemySpawner = enemySpawner;
			_musicSwitcher = musicSwitcher;
			_transientGameDataService = transientGameDataService;
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
			LevelStaticData levelStaticData = _transientGameDataService.Data.LevelData.CurrentLevelStaticData;

			await _enemySpawner.Spawn(levelStaticData);
		}

		private void PlayEnemyBattleMusic() =>
			_musicSwitcher.PlayEnemyBattle();
	}
}