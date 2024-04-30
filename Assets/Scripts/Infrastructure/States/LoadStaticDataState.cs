using Cysharp.Threading.Tasks;
using Infrastructure.Services.StaticData;
using Infrastructure.States.StateMachine;

namespace Infrastructure.States
{
	public class LoadStaticDataState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly IStaticDataService _staticDataService;

		public LoadStaticDataState(IGameStateMachine gameStateMachine, IStaticDataService staticDataService)
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