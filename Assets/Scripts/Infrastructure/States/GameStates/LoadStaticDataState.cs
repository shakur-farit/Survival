using Cysharp.Threading.Tasks;
using Infrastructure.Services.StaticData;
using Infrastructure.States.GameStates.StatesMachine;

namespace Infrastructure.States.GameStates
{
	public class LoadStaticDataState : IGameState
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IStaticDataService _staticDataService;

		public LoadStaticDataState(IGameStatesSwitcher gameStatesSwitcher, IStaticDataService staticDataService)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
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
			_gameStatesSwitcher.SwitchState<LoadProgressState>();
	}
}