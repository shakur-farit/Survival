using Data;
using Infrastructure.Services.PersistentProgress;

namespace Infrastructure.States
{
	public class LoadProgressState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly PersistentProgressService _persistentProgressService;

		public LoadProgressState(GameStateMachine gameStateMachine, PersistentProgressService persistentProgressService)
		{
			_gameStateMachine = gameStateMachine;
			_persistentProgressService = persistentProgressService;
		}

		public void Enter()
		{
			InitializeNewProgress();

			EnterToLoadLevelState();
		}

		public void Exit()
		{
		}

		private void InitializeNewProgress() => 
			_persistentProgressService.Progress = new Progress();

		private void EnterToLoadLevelState() => 
			_gameStateMachine.Enter<LoadLevelState>();
	}
}