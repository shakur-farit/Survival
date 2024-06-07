using EnemyLogic.States;
using EnemyLogic.States.StateMachine;
using Infrastructure.Services.Factories.States;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyStateRegistrar : MonoBehaviour
	{
		[SerializeField] private EnemyAimStateMachine stateMachine;

		private IEnemyAimStatesRegistrar _statesRegistrar;
		private IStatesFactory _statesFactory;

		[Inject]
		public void Constructor( IStatesFactory stateFactory) => 
			_statesFactory = stateFactory;

		private void Awake()
		{
			_statesRegistrar = stateMachine;

			RegisterEnemyStates();
		}

		private void RegisterEnemyStates()
		{
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimUpState>());
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimUpRightState>());
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimUpLeftState>());
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimRightState>());
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimLeftState>());
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimDownState>());
		}
	}


}