using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Timer;
using Infrastructure.States.GameLoopStates;
using Infrastructure.States.GameLoopStates.StatesMachine;
using Soundtrack;

namespace Infrastructure.States.GameStates
{
	public class LevelStartState : IGameLoopState
	{
		private readonly IMusicSwitcher _musicSwitcher;
		private readonly ICountDownTimer _timer;
		private readonly IGameLoopStatesSwitcher _gameLoopStatesSwitcher;
		private readonly IPersistentProgressService _persistentProgressService;

		public LevelStartState(IMusicSwitcher musicSwitcher, ICountDownTimer timer, 
			IGameLoopStatesSwitcher gameLoopStatesSwitcher, IPersistentProgressService persistentProgressService)
		{
			_musicSwitcher = musicSwitcher;
			_timer = timer;
			_gameLoopStatesSwitcher = gameLoopStatesSwitcher;
			_persistentProgressService = persistentProgressService;
		}

		public async void Enter()
		{
			_musicSwitcher.PlayClearedRoom();

			await StartTimer();

			_timer.Completed += SwitchToEnemyBattleState;
		}

		public void Exit() => 
			_timer.Completed -= SwitchToEnemyBattleState;

		private async UniTask StartTimer() =>
			await _timer.Start(_persistentProgressService.Progress.LevelData.CurrentLevelStaticData.TimeToStart);

		private void SwitchToEnemyBattleState() => 
			_gameLoopStatesSwitcher.SwitchState<EnemyBattleState>();
	}
}