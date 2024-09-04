using Character.Factory;
using Cysharp.Threading.Tasks;
using Enemy.Factory;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using Pool;
using Spawn;
using UI.Factory;
using UI.Services.Windows;
using UI.Windows;
using UnityEngine;
using Utility;

namespace Infrastructure.States
{
	public class GameOverState : IGameState
	{
		private readonly IWindowsService _windowService;
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IEnemyFactory _enemyFactory;
		private readonly IEnemySpawner _enemySpawner;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IUIFactory _uiFactory;
		private readonly IObjectsPool _objectsPool;

		public GameOverState(IWindowsService windowService, ICharacterFactory characterFactory, 
			IHudFactory hudFactory, IEnemyFactory enemyFactory, IEnemySpawner enemySpawner, 
			IPersistentProgressService persistentProgressService, IUIFactory uiFactory,
			IObjectsPool objectsPool)
		{
			_windowService = windowService;
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_enemyFactory = enemyFactory;
			_enemySpawner = enemySpawner;
			_persistentProgressService = persistentProgressService;
			_uiFactory = uiFactory;
			_objectsPool = objectsPool;
		}

		public async void Enter()
		{
			await OpenGameOverWindow();
			StopEnemiesSpawn();
			DestroyObjects();
			ResetData();
			ClearPoolObjects();
		}

		public void Exit() => 
			DestroyUIRoot();

		private async UniTask OpenGameOverWindow() => 
			await _windowService.Open(WindowType.GameOver);

		private void StopEnemiesSpawn() => 
			_enemySpawner.StopSpawn();

		private void DestroyObjects()
		{
			DestroyCharacter();
			DestroyHud();
			DestroyEnemies();
		}

		private void DestroyCharacter() =>
			_characterFactory.Destroy();

		private void DestroyHud() =>
			_hudFactory.Destroy();

		private void DestroyEnemies()
		{
			foreach (GameObject enemy in _enemyFactory.EnemiesList) 
				_enemyFactory.Destroy(enemy);

			_enemyFactory.EnemiesList.Clear();
		}

		private void DestroyUIRoot() => 
			_uiFactory.DestroyUIRoot();

		private void ResetData()
		{
			_persistentProgressService.Progress.LevelData.PreviousLevel = Constants.Zero;
			_persistentProgressService.Progress.ScoreData.CurrentScore = Constants.Zero;
			_persistentProgressService.Progress.EnemyData.DeadEnemies.Clear();
		}

		private void ClearPoolObjects() => 
			_objectsPool.ClearDictionaries();
	}
}