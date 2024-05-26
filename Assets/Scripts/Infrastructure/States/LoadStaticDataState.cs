using Cysharp.Threading.Tasks;
using Infrastructure.Services.StaticData;
using Infrastructure.States.StateMachine;

namespace Infrastructure.States
{
	public class LoadStaticDataState : IState
	{
		private readonly IGameStateSwitcher _gameStateSwitcher;
		private readonly IStaticDataService _staticDataService;

		public LoadStaticDataState(IGameStateSwitcher gameStateSwitcher, IStaticDataService staticDataService)
		{
			_gameStateSwitcher = gameStateSwitcher;
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
			_gameStateSwitcher.SwitchState<LoadProgressState>();
	}
}