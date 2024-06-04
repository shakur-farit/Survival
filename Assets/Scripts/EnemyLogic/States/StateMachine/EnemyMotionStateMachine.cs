using System;
using System.Collections.Generic;
using Infrastructure.States;

namespace EnemyLogic.States.StateMachine
{
	public class EnemyAimStateMachine : IEnemyAimStatesSwitcher, IEnemyAimStatesRegister
	{
		private readonly Dictionary<Type, IEnemyAnimatorState> _statesDictionary = new();
		private IEnemyAnimatorState _activeState;

		public void SwitchState<TState>(EnemyAnimator enemyAnimator) where TState : IEnemyAnimatorState
		{
			_activeState?.Exit(enemyAnimator);
			IEnemyAnimatorState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter(enemyAnimator);
		}

		public void RegisterState<TState>(TState state) where TState : IEnemyAnimatorState =>
			_statesDictionary.Add(typeof(TState), state);
	}
}