using Infrastructure.Services.AssetsManagement;

namespace Infrastructure.States
{
	public class AddressablesInitializeState : IState
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly GameStateMachine _gameStateMachine;

		public AddressablesInitializeState(GameStateMachine gameStateMachine, AssetsProvider assetsProvider)
		{
			_gameStateMachine = gameStateMachine;
			_assetsProvider = assetsProvider;
		}

		public void Enter()
		{
			_assetsProvider.Initialize();

			EnterInWarmUpState();
		}

		public void Exit()
		{
		}

		private void EnterInWarmUpState() => 
			_gameStateMachine.Enter<WarmUpState>();
	}
}