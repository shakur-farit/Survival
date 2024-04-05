using Infrastructure.Services.StaticData;

namespace Infrastructure.States
{
	public class LoadStaticDataState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly StaticDataService _staticDataService;

		public LoadStaticDataState(GameStateMachine gameStateMachine, StaticDataService staticDataService)
		{
			_gameStateMachine = gameStateMachine;
			_staticDataService = staticDataService;
		}

		public void Enter()
		{
			LoadStaticData();
			EnterToGameLoopingState();
		}

		public void Exit()
		{
		}

		private void LoadStaticData() => 
			_staticDataService.Load();

		private void EnterToGameLoopingState() => 
			_gameStateMachine.Enter<LoadLevelState>();
	}
}