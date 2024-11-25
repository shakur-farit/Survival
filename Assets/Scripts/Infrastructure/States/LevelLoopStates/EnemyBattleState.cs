using Infrastructure.Services.PersistentProgress;
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
			Debug.Log(GetType());


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