using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.StaticData;
using Infrastructure.States.GameStates.StatesMachine;

namespace Infrastructure.States.GameStates
{
	public class WarmUpState : IGameState
	{
		private readonly IAssetsProvider _assetsProvider;
		private readonly IStaticDataService _staticDataService;
		private readonly IGameStatesSwitcher _gameStatesSwitcher;

		public WarmUpState(IAssetsProvider assetsProvider, IStaticDataService staticDataService, IGameStatesSwitcher gameStatesSwitcher)
		{
			_assetsProvider = assetsProvider;
			_staticDataService = staticDataService;
			_gameStatesSwitcher = gameStatesSwitcher;
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
			await _assetsProvider.Load<UIAssetsReference>(AssetsReferenceAddress.UIAssetsReference);
			await _staticDataService.WarmUp();
		}

		private void CleanUp() => 
			_assetsProvider.CleanUp();

		private void EnterToLoadStaticDataState() =>
			_gameStatesSwitcher.SwitchState<LoadStaticDataState>();
	}
}