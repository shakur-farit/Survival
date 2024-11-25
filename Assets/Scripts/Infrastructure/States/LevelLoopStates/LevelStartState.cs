using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Timer;
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
		private readonly IPersistentProgressService _persistentProgressService;

		public LevelStartState(IMusicSwitcher musicSwitcher, ICountDownTimer timer, 
			ILevelLoopStatesSwitcher levelLoopStatesSwitcher, IPersistentProgressService persistentProgressService)
		{
			_musicSwitcher = musicSwitcher;
			_timer = timer;
			_levelLoopStatesSwitcher = levelLoopStatesSwitcher;
			_persistentProgressService = persistentProgressService;
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
			await _timer.Start(_persistentProgressService.Progress.LevelData.CurrentLevelStaticData.TimeToStart);

		private void SwitchToEnemyBattleState() => 
			_levelLoopStatesSwitcher.SwitchState<EnemyBattleState>();
	}
}