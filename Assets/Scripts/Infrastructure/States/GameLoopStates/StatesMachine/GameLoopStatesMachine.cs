using System;
using System.Collections.Generic;

namespace Infrastructure.States.GameLoopStates.StatesMachine
{
	public class GameLoopStatesMachine : IGameLoopStatesSwitcher, IGameLoopStatesRegistrar
	{
		private readonly Dictionary<Type, IGameLoopState> _statesDictionary = new();
		private IGameLoopState _activeState;

		public void SwitchState<TState>() where TState : IGameLoopState
		{
			_activeState?.Exit();
			IGameLoopState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : IGameLoopState =>
			_statesDictionary.Add(typeof(TState), state);

	}
}