using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using Infrastructure.States.StateMachine;

public class WarmUpState : IState
{
	private readonly AssetsProvider _assetsProvider;
	private readonly StaticDataService _staticDataService;
	private readonly GameStateMachine _gameStateMachine;

	public WarmUpState(AssetsProvider assetsProvider, StaticDataService staticDataService, GameStateMachine gameStateMachine)
	{
		_assetsProvider = assetsProvider;
		_staticDataService = staticDataService;
		_gameStateMachine = gameStateMachine;
	}

	public async void Enter()
	{
		InitializeAssets();

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
	private void EnterToLoadStaticDataState() =>
		_gameStateMachine.Enter<LoadStaticDataState>();
}