using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.Factories.Hud;
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

		public GameOverState(IWindowsService windowService, ICharacterFactory characterFactory, 
			IHudFactory hudFactory, IEnemyFactory enemyFactory)
		{
			_windowService = windowService;
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_enemyFactory = enemyFactory;
		}

		public async void Enter()
		{
			await OpenGameOverWindow();

			DestroyObjects();
		}

		public void Exit() => 
			CloseGameOverWindow();

		private void CloseGameOverWindow() => 
			_windowService.Close(WindowType.GameOver);

		private async UniTask OpenGameOverWindow() => 
			await _windowService.Open(WindowType.GameOver);

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
			{
				_enemyFactory.EnemiesList.Remove(enemy);
				_enemyFactory.Destroy(enemy);
			}
		}
	}
}