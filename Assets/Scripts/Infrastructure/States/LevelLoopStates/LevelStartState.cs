using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Timer;
using Infrastructure.Services.TransientGameData;
using Infrastructure.States.LevelLoopStates.StatesMachine;
using Soundtrack;
using UnityEngine;

namespace Infrastructure.States.LevelLoopStates
{
	public class LevelStartState : ILevelLoopState
	{
		private readonly IMusicSwitcher _musicSwitcher;
		private readonly ICountDownTimer _timer;
		private readonly ILevelLoopStatesSwitcher _levelLoopStatesSwitcher;
		private readonly ITransientGameDataService _transientGameDataService;

		public LevelStartState(IMusicSwitcher musicSwitcher, ICountDownTimer timer, 
			ILevelLoopStatesSwitcher levelLoopStatesSwitcher, ITransientGameDataService transientGameDataService)
		{
			_musicSwitcher = musicSwitcher;
			_timer = timer;
			_levelLoopStatesSwitcher = levelLoopStatesSwitcher;
			_transientGameDataService = transientGameDataService;
		}

		public async void Enter()
		{
			_timer.Completed += SwitchToEnemyBattleState;
			Debug.Log(GetType());

			_musicSwitcher.PlayClearedRoom();

			await StartTimer();
		}

		public void Exit() => 
			_timer.Completed -= SwitchToEnemyBattleState;

		private async UniTask StartTimer() =>
			await _timer.Start(_transientGameDataService.Data.LevelData.CurrentLevelStaticData.TimeToStart);

		private void SwitchToEnemyBattleState() => 
			_levelLoopStatesSwitcher.SwitchState<EnemyBattleState>();
	}
}