using System;
using System.Collections.Generic;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using UI.Services.Factory;
using UI.Services.Windows;

namespace Infrastructure.States
{
	public class GameStateMachine
	{
		private Dictionary<Type, IState> _statesDictionary;
		private IState _activeState;

		public GameStateMachine(StaticDataService staticDataService, AssetsProvider assetsProvider, PersistentProgressService persistentProgressService,
			WindowsService windowsService, GameFactory gameFactory, UIFactory uiFactory)
		{
			_statesDictionary = new Dictionary<Type, IState>()
			{
				[typeof(WarmUpState)] = new WarmUpState(this, staticDataService, assetsProvider, gameFactory, uiFactory),
				[typeof(LoadStaticDataState)] = new LoadStaticDataState(this, staticDataService),
				[typeof(LoadProgressState)] = new LoadProgressState(this, persistentProgressService),
				[typeof(LoadSceneState)] = new LoadSceneState(this, assetsProvider, uiFactory),
				[typeof(MainMenuState)] = new MainMenuState(this, windowsService),
				[typeof(GameLoopingState)] = new GameLoopingState(this),
				[typeof(LoadLevelState)] = new LoadLevelState(this, gameFactory, assetsProvider,persistentProgressService, staticDataService),
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