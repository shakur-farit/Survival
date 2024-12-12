using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Timer;
using Infrastructure.Services.TransientGameData;
using Infrastructure.States.GameStates;
using Infrastructure.States.GameStates.StatesMachine;
using Infrastructure.States.LevelLoopStates.StatesMachine;
using Soundtrack;
using UnityEngine;
using Utility;

namespace Infrastructure.States.LevelLoopStates
{
	public class LevelEndState : ILevelLoopState
	{
		private readonly ICountDownTimer _timer;
		private readonly ITransientGameDataService _transientGameDataService;
		private readonly IMusicSwitcher _musicSwitcher;
		private readonly ILevelLoopStatesSwitcher _levelLoopStatesSwitcher;
		private readonly IGameStatesSwitcher _gameStatesSwitcher;

		public LevelEndState(ICountDownTimer timer, ITransientGameDataService transientGameDataService, 
			IMusicSwitcher musicSwitcher, ILevelLoopStatesSwitcher levelLoopStatesSwitcher, 
			IGameStatesSwitcher gameStatesSwitcher)
		{
			_timer = timer;
			_transientGameDataService = transientGameDataService;
			_musicSwitcher = musicSwitcher;
			_levelLoopStatesSwitcher = levelLoopStatesSwitcher;
			_gameStatesSwitcher = gameStatesSwitcher;
		}

		public void Enter()
		{
			Debug.Log(GetType());

			_timer.Completed += SwitchState;

			StartTimer();
		}

		public void Exit() => 
			_timer.Completed -= SwitchState;

		private void SwitchState()
		{
			SetupNextLevel();

			EnterToClearState();
			EnterToLevelCompleteState();
		}

		private void SetupNextLevel() =>
			_transientGameDataService.Data.LevelData.PreviousLevel += Constants.NextLevelStep;


		private void StartTimer()
		{
			_musicSwitcher.PlayClearedRoom();

			_timer.Start(_transientGameDataService.Data.LevelData.CurrentLevelStaticData.TimeToCompleteLevel);

			Debug.Log("Timer is complete");
		}

		private void EnterToClearState() => 
			_levelLoopStatesSwitcher.SwitchState<LevelClearState>();

		private void EnterToLevelCompleteState() => 
			_gameStatesSwitcher.SwitchState<LevelCompleteState>();
	}
}