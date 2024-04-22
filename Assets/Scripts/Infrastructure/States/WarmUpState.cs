using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.StaticData;
using UI.Services.Factory;

namespace Infrastructure.States
{
	public class WarmUpState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly StaticDataService _staticDataService;
		private readonly AssetsProvider _assetsProvider;
		private readonly GameFactory _gameFactory;
		private readonly UIFactory _uiFactory;
		private readonly AmmoFactory _ammoFactory;

		public WarmUpState(GameStateMachine gameStateMachine, StaticDataService staticDataService, AssetsProvider assetsProvider, 
			GameFactory gameFactory, UIFactory uiFactory, AmmoFactory ammoFactory)
		{
			_gameStateMachine = gameStateMachine;
			_staticDataService = staticDataService;
			_assetsProvider = assetsProvider;
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_ammoFactory = ammoFactory;
		}

		public async void Enter()
		{
			InitializeAssets();

			await WarmUpAssets();

			EnterInLoadStaticDataState();
		}

		public void Exit()
		{
		}

		private async UniTask WarmUpAssets()
		{
			await _gameFactory.WarmUp();
			await _uiFactory.WarmUp();
			await _ammoFactory.WarmUp();
			await _staticDataService.WarmUp();
		}

		private void InitializeAssets() => 
			_assetsProvider.Initialize();

		private void EnterInLoadStaticDataState() => 
			_gameStateMachine.Enter<LoadStaticDataState>();
	}
}