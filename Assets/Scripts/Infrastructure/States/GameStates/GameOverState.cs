using Coin;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.TransientGameData;
using Pool;
using Soundtrack;
using Soundtrack.Factory;
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
		private readonly ITransientGameDataService _transientGameDataService;
		private readonly IUIFactory _uiFactory;
		private readonly IPoolFactory _poolFactory;
		private readonly IMusicSwitcher _musicSwitcher;
		private readonly IMusicSourceFactory _musicSourceFactory;
		private readonly IScoreCounter _scoreCounter;

		public GameOverState(IWindowsService windowService, ITransientGameDataService transientGameDataService,
			IUIFactory uiFactory, IPoolFactory poolFactory, IMusicSwitcher musicSwitcher, 
			IMusicSourceFactory musicSourceFactory, IScoreCounter scoreCounter)
		{
			_windowService = windowService;
			_transientGameDataService = transientGameDataService;
			_uiFactory = uiFactory;
			_poolFactory = poolFactory;
			_musicSwitcher = musicSwitcher;
			_musicSourceFactory = musicSourceFactory;
			_scoreCounter = scoreCounter;
		}

		public async void Enter()
		{
			Debug.Log(GetType());

			_musicSwitcher.PlayDungeonMelancholy();

			await OpenGameOverWindow();
			ResetData();
		}

		public void Exit()
		{
			DestroyUIRoot();
			DestroyMusicSource();
			DestroyPoolsGroup();
			ClearPoolObjects();
		}

		private async UniTask OpenGameOverWindow() => 
			await _windowService.Open(WindowType.GameOver);

		private void DestroyUIRoot() => 
			_uiFactory.DestroyUIRoot();

		private void ResetData()
		{
			_transientGameDataService.Data.LevelData.PreviousLevel = Constants.Zero;
			_transientGameDataService.Data.CoinData.CurrentCoinCount = Constants.Zero;
			_transientGameDataService.Data.EnemyData.DeadEnemies.Clear();
			_scoreCounter.ResetScore();
		}

		private void ClearPoolObjects() => 
			_poolFactory.ClearPools();

		private void DestroyMusicSource() => 
			_musicSourceFactory.Destroy();

		private void DestroyPoolsGroup() => 
			_poolFactory.DestroyPoolsGroup();
	}
}