using Infrastructure.Services.Factory;
using Infrastructure.Services.StaticData;

namespace Infrastructure.States
{
	public class WarmUpState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly GameFactory _gameFactory;
		private readonly StaticDataService _staticDataService;

		public WarmUpState(GameStateMachine gameStateMachine, GameFactory gameFactory, StaticDataService staticDataService)
		{
			_gameStateMachine = gameStateMachine;
			_gameFactory = gameFactory;
			_staticDataService = staticDataService;
		}

		public async void Enter()
		{
			await _gameFactory.WarmUp();
			await _staticDataService.WarmUp();

			EnterInLoadStaticDataState();
		}

		public void Exit()
		{
		}

		private void EnterInLoadStaticDataState() => 
			_gameStateMachine.Enter<LoadStaticDataState>();
	}
}