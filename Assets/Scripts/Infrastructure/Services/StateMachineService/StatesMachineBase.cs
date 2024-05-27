using System;
using System.Collections.Generic;
using Infrastructure.States;

namespace Infrastructure.Services.StateMachineService
{
	public class StatesMachineBase
	{
		protected readonly Dictionary<Type, IState> StatesDictionary = new();
		protected IState ActiveState;

		public void SwitchState<TState>() where TState : IState
		{
			ActiveState?.Exit();
			IState state = StatesDictionary[typeof(TState)];
			ActiveState = state;
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : IState =>
			StatesDictionary.Add(typeof(TState), state);
	}
}