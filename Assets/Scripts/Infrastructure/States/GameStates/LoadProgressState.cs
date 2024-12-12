using Data;
using Data.Persistent;
using Infrastructure.Services.Dialog;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticData;
using Infrastructure.States.GameStates.StatesMachine;

namespace Infrastructure.States.GameStates
{
	public class LoadProgressState : IGameState
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IStaticDataService _staticDataService;
		private readonly ILoadService _loadService;

		public LoadProgressState(IGameStatesSwitcher gameStatesSwitcher, IPersistentProgressService persistentProgressService, 
			IStaticDataService staticDataService, ILoadService loadService)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
			_loadService = loadService;
		}

		public void Enter()
		{
			InitializeProgress();

			EnterToLoadSceneState();
		}

		public void Exit()
		{
		}

		private void InitializeProgress()
		{
			_persistentProgressService.Progress = _loadService.LoadProgress();
			_persistentProgressService.IsNew = true;
		}

		private void EnterToLoadSceneState() => 
			_gameStatesSwitcher.SwitchState<MainMenuState>();
	}
}