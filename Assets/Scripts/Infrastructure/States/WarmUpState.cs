using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.StaticData;
using Infrastructure.States.StateMachine;

namespace Infrastructure.States
{
	public class WarmUpState : IState
	{
		private readonly IAssetsProvider _assetsProvider;
		private readonly IStaticDataService _staticDataService;
		private readonly IGameStateMachine _gameStateMachine;

		public WarmUpState(IAssetsProvider assetsProvider, IStaticDataService staticDataService, IGameStateMachine gameStateMachine)
		{
			_assetsProvider = assetsProvider;
			_staticDataService = staticDataService;
			_gameStateMachine = gameStateMachine;
		}

		public async void Enter()
		{
			InitializeAssets();
			CleanUp();
			await WarmUpAssets();
			EnterToLoadStaticDataState();
		}

		public void Exit()
		{
		}

		private void InitializeAssets() =>
			_assetsProvider.Initialize();

		private async UniTask WarmUpAssets()
		{
			await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			await _staticDataService.WarmUp();
		}

		private void CleanUp() => 
			_assetsProvider.CleanUp();

		private void EnterToLoadStaticDataState() =>
			_gameStateMachine.Enter<LoadStaticDataState>();
	}
}