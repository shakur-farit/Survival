using Cysharp.Threading.Tasks;
using Infrastructure.Services.StaticData;
using Infrastructure.States.StateMachine;

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

		public async void Enter()
		{
			await LoadStaticData();

			EnterToLoadProgressState();
		}

		public void Exit()
		{
		}

		private async UniTask LoadStaticData() => 
			await _staticDataService.Load();

		private void EnterToLoadProgressState() => 
			_gameStateMachine.Enter<LoadProgressState>();
	}
}