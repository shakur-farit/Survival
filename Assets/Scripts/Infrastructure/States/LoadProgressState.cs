using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.States.StatesMachine;

namespace Infrastructure.States
{
	public class LoadProgressState : IGameState
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IStaticDataService _staticDataService;

		public LoadProgressState(IGameStatesSwitcher gameStatesSwitcher, IPersistentProgressService persistentProgressService, 
			IStaticDataService staticDataService)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
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