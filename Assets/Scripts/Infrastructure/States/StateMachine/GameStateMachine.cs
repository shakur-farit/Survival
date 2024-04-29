using System;
using System.Collections.Generic;

namespace Infrastructure.States.StateMachine
{
	public class GameStateMachine
	{
		private readonly Dictionary<Type, IState> _statesDictionary = new();
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