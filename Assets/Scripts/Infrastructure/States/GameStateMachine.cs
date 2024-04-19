using System;
using System.Collections.Generic;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;

namespace Infrastructure.States
{
	public class GameStateMachine
	{
		private Dictionary<Type, IState> _statesDictionary;
		private IState _activeState;

		public GameStateMachine(StaticDataService staticDataService, AssetsProvider assetsProvider, GameFactory gameFactory,
			PersistentProgressService persistentProgressService)
		{
			_statesDictionary = new Dictionary<Type, IState>()
			{
				[typeof(AddressablesInitializeState)] = new AddressablesInitializeState(this, assetsProvider),
				[typeof(WarmUpState)] = new WarmUpState(this, gameFactory,staticDataService),
				[typeof(LoadStaticDataState)] = new LoadStaticDataState(this, staticDataService),
				[typeof(LoadProgressState)] = new LoadProgressState(this, persistentProgressService),
				[typeof(LoadLevelState)] = new LoadLevelState(this, gameFactory, assetsProvider,persistentProgressService, staticDataService),
				[typeof(GameLoopingState)] = new GameLoopingState(),
			};
		}


		public void Enter<TState>() where TState : IState
		{
			_activeState?.Exit();
			IState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}
	}
}