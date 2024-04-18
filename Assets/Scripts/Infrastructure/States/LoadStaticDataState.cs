using System.Threading.Tasks;
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

		public async void Enter()
		{
			await LoadStaticData();

			SetupCharacter();

			EnterToLoadProgressState();
		}

		public void Exit()
		{
		}

		private async Task LoadStaticData() => 
			await _staticDataService.Load();

		private void SetupCharacter() => 
			_staticDataService.SetupDataForCharacter();

		private void EnterToLoadProgressState() => 
			_gameStateMachine.Enter<LoadProgressState>();
	}
}