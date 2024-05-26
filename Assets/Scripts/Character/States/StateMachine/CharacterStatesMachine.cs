using System;
using System.Collections.Generic;
using Infrastructure.States;

namespace Character.States.StateMachine
{
	public class CharacterStatesMachine : ICharacterStatesRegistrar, ICharacterStatesSwitcher
	{
		private readonly Dictionary<Type, IState> _statesDictionary = new();
		private IState _activeState;

		public void SwitchState<TState>() where TState : IState
		{
			_activeState?.Exit();
			IState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : IState =>
			_statesDictionary.Add(typeof(TState), state);
	}
}