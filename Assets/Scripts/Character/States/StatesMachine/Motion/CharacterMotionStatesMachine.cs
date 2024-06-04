using System;
using System.Collections.Generic;

namespace Character.States.StatesMachine.Motion
{
	public class CharacterMotionStatesMachine : ICharacterMotionStatesRegistrar, ICharacterMotionStatesSwitcher
	{
		private readonly Dictionary<Type, ICharacterAnimatorState> _statesDictionary = new();
		private ICharacterAnimatorState _activeState;

		public void SwitchState<TState>(CharacterAnimator characterAnimator) where TState : ICharacterAnimatorState
		{
			_activeState?.Exit(characterAnimator);
			ICharacterAnimatorState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter(characterAnimator);
		}

		public void RegisterState<TState>(TState state) where TState : ICharacterAnimatorState =>
			_statesDictionary.Add(typeof(TState), state);
	}
}