using System;
using EnemyLogic.States;
using EnemyLogic.States.StateMachine;
using Infrastructure.Services.Factories.States;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace EnemyLogic
{
	public class EnemyStateRegistrar : MonoBehaviour
	{
		[SerializeField] private EnemyAimStateMachine stateMachine;

		private IEnemyAimStatesRegister _statesRegister;
		private IStatesFactory _statesFactory;

		[Inject]
		public void Constructor( IStatesFactory stateFactory) => 
			_statesFactory = stateFactory;

		private void Awake() => 
			_statesRegister = stateMachine;

		private void Start() => 
			RegisterEnemyStates();

		private void RegisterEnemyStates()
		{
			_statesRegister.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimUpState>());
			_statesRegister.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimUpRightState>());
			_statesRegister.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimUpLeftState>());
			_statesRegister.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimRightState>());
			_statesRegister.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimLeftState>());
			_statesRegister.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimDownState>());
		}
	}


}