using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Timer;
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
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IMusicSwitcher _musicSwitcher;
		private readonly ILevelLoopStatesSwitcher _levelLoopStatesSwitcher;
		private readonly IGameStatesSwitcher _gameStatesSwitcher;

		public LevelEndState(ICountDownTimer timer, IPersistentProgressService persistentProgressService, 
			IMusicSwitcher musicSwitcher, ILevelLoopStatesSwitcher levelLoopStatesSwitcher, 
			IGameStatesSwitcher gameStatesSwitcher)
		{
			_timer = timer;
			_persistentProgressService = persistentProgressService;
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
			_persistentProgressService.Progress.LevelData.PreviousLevel += Constants.NextLevelStep;


		private void StartTimer()
		{
			_musicSwitcher.PlayClearedRoom();

			_timer.Start(_persistentProgressService.Progress.LevelData.CurrentLevelStaticData.TimeToCompleteLevel);
		}

		private void EnterToClearState() => 
			_levelLoopStatesSwitcher.SwitchState<LevelClearState>();

		private void EnterToLevelCompleteState() => 
			_gameStatesSwitcher.SwitchState<LevelCompleteState>();
	}
}