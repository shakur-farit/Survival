using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.States.StateMachine;

namespace Infrastructure.States
{
	public class LoadProgressState : IState
	{
		private readonly IGameStateSwitcher _gameStateSwitcher;
		private readonly IPersistentProgressService _persistentProgressService;

		public LoadProgressState(IGameStateSwitcher gameStateSwitcher, IPersistentProgressService persistentProgressService)
		{
			_gameStateSwitcher = gameStateSwitcher;
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
			_gameStateSwitcher.SwitchState<LoadSceneState>();
	}
}