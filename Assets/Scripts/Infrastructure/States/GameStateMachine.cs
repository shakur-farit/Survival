using System;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.States
{
	public class GameStateMachine
	{
		private Dictionary<Type, IState> _statesDictionary = new();
		private IState _activeState;

		public void Enter<TState>() where TState : IState
		{
			_activeState?.Exit();
			IState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : IState=>
			_statesDictionary.Add(typeof(TState), state);
	}
}