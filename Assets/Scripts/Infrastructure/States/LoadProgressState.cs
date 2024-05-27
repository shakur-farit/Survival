using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.States.StatesMachine;

namespace Infrastructure.States
{
	public class LoadProgressState : IState
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IPersistentProgressService _persistentProgressService;

		public LoadProgressState(IGameStatesSwitcher gameStatesSwitcher, IPersistentProgressService persistentProgressService)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
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
			_gameStatesSwitcher.SwitchState<LoadSceneState>();
	}
}