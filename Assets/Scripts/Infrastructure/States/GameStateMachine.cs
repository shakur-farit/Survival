using System;
using System.Collections.Generic;
using Infrastructure.Services.StaticData;

namespace Infrastructure.States
{
	public class GameStateMachine
	{
		private Dictionary<Type, IState> _statesDictionary;
		private IState _activeState;

		public GameStateMachine(StaticDataService staticDataService)
		{
			_statesDictionary = new Dictionary<Type, IState>()
			{
				[typeof(LoadStaticDataState)] = new LoadStaticDataState(this, staticDataService),
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