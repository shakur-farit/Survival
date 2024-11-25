using System;
using System.Collections.Generic;

namespace Infrastructure.States.LevelLoopStates.StatesMachine
{
	public class LevelLoopStatesMachine : ILevelLoopStatesSwitcher, ILevelLoopStatesRegistrar
	{
		private readonly Dictionary<Type, ILevelLoopState> _statesDictionary = new();
		private ILevelLoopState _activeState;

		public void SwitchState<TState>() where TState : ILevelLoopState
		{
			_activeState?.Exit();
			ILevelLoopState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : ILevelLoopState =>
			_statesDictionary.Add(typeof(TState), state);

	}
}