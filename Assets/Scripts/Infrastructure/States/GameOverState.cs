using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.Factories.Hud;
using Spawn;
using UI.Services.Windows;
using UI.Windows;
using UnityEngine;

namespace Infrastructure.States
{
	public class GameOverState : IGameState
	{
		private readonly IWindowsService _windowService;
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IEnemyFactory _enemyFactory;
		private readonly IEnemySpawner _enemySpawner;

		public GameOverState(IWindowsService windowService, ICharacterFactory characterFactory, 
			IHudFactory hudFactory, IEnemyFactory enemyFactory, IEnemySpawner enemySpawner)
		{
			_windowService = windowService;
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_enemyFactory = enemyFactory;
			_enemySpawner = enemySpawner;
		}

		public async void Enter()
		{
			await OpenGameOverWindow();
			StopEnemiesSpawn();
			DestroyObjects();
		}

		public void Exit() => 
			CloseGameOverWindow();

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

		private void CloseGameOverWindow() => 
			_windowService.Close(WindowType.GameOver);
	}
}