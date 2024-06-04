using System;
using System.Collections.Generic;

namespace Infrastructure.States.StatesMachine
{
	public class GameStatesMachine : IGameStatesSwitcher, IGameStatesRegistrar
	{
		private readonly Dictionary<Type, IGameState> _statesDictionary = new();
		private IGameState _activeState;

		public void SwitchState<TState>() where TState : IGameState
		{
			_activeState?.Exit();
			IGameState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : IGameState =>
			_statesDictionary.Add(typeof(TState), state);
	}
}