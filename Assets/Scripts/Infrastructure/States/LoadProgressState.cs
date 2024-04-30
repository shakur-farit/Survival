using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.States.StateMachine;

namespace Infrastructure.States
{
	public class LoadProgressState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly IPersistentProgressService _persistentProgressService;

		public LoadProgressState(IGameStateMachine gameStateMachine, IPersistentProgressService persistentProgressService)
		{
			_gameStateMachine = gameStateMachine;
			_persistentProgressService = persistentProgressService;
		}

		public void Enter()
		{
			InitializeNewProgress();

			EnterToLoadSceneState();
		}

		public void Exit()
		{
		}

		private void InitializeNewProgress() => 
			_persistentProgressService.Progress = new Progress();

		private void EnterToLoadSceneState() => 
			_gameStateMachine.Enter<LoadSceneState>();
	}
}