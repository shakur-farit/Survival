using Camera.Factory;
using Character.Factory;
using Cysharp.Threading.Tasks;
using Enemy.Factory;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using Pool;
using Room.Factory;
using Soundtrack;
using Soundtrack.Factory;
using Spawn;
using UI.Factory;
using UI.Services.Windows;
using UI.Windows;
using UnityEngine;
using Utility;

namespace Infrastructure.States.GameStates
{
	public class GameOverState : IGameState
	{
		private readonly IWindowsService _windowService;
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IEnemyFactory _enemyFactory;
		private readonly IEnemySpawner _enemySpawner;
		private readonly ITransientGameDataService _transientGameDataService;
		private readonly IUIFactory _uiFactory;
		private readonly IPoolFactory _poolFactory;
		private readonly IVirtualCameraFactory _virtualCameraFactory;
		private readonly IRoomFactory _tilemapFactory;
		private readonly IMusicSwitcher _musicSwitcher;
		private readonly IMusicSourceFactory _musicSourceFactory;

		public GameOverState(IWindowsService windowService, ICharacterFactory characterFactory, 
			IHudFactory hudFactory, IEnemyFactory enemyFactory, IEnemySpawner enemySpawner,
			ITransientGameDataService transientGameDataService, IUIFactory uiFactory,
			IPoolFactory poolFactory, IVirtualCameraFactory virtualCameraFactory, 
			IRoomFactory tilemapFactory, IMusicSwitcher musicSwitcher, IMusicSourceFactory musicSourceFactory)
		{
			_windowService = windowService;
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_enemyFactory = enemyFactory;
			_enemySpawner = enemySpawner;
			_transientGameDataService = transientGameDataService;
			_uiFactory = uiFactory;
			_poolFactory = poolFactory;
			_virtualCameraFactory = virtualCameraFactory;
			_tilemapFactory = tilemapFactory;
			_musicSwitcher = musicSwitcher;
			_musicSourceFactory = musicSourceFactory;
		}

		public async void Enter()
		{
			_musicSwitcher.PlayDungeonMelancholy();

			await OpenGameOverWindow();
			StopEnemiesSpawn();
			DestroyObjects();
			ResetData();
			ClearPoolObjects();
		}

		public void Exit()
		{
			DestroyUIRoot();
			DestroyMusicSource();
			DestroyPoolsGroup();
		}

		private async UniTask OpenGameOverWindow() => 
			await _windowService.Open(WindowType.GameOver);

		private void StopEnemiesSpawn() => 
			_enemySpawner.StopSpawn();

		private void DestroyObjects()
		{
			DestroyVirtualCamera();
			DestroyCharacter();
			DestroyHud();
			DestroyEnemies();
			DestroyTilemap();
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

		private void DestroyTilemap() => 
			_tilemapFactory.Destroy();

		private void DestroyUIRoot() => 
			_uiFactory.DestroyUIRoot();

		private void DestroyVirtualCamera() => 
			_virtualCameraFactory.Destroy();

		private void ResetData()
		{
			_transientGameDataService.Data.LevelData.PreviousLevel = Constants.Zero;
			_transientGameDataService.Data.CoinData.CurrentCoinCount = Constants.Zero;
			_transientGameDataService.Data.EnemyData.DeadEnemies.Clear();
		}

		private void ClearPoolObjects() => 
			_poolFactory.ClearPools();

		private void DestroyMusicSource() => 
			_musicSourceFactory.Destroy();

		private void DestroyPoolsGroup() => 
			_poolFactory.DestroyPoolsGroup();
	}
}