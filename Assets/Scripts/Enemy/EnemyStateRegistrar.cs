using Enemy.States;
using Enemy.States.StateMachine;
using Infrastructure.States.Factory;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyStateRegistrar : MonoBehaviour
	{
		[SerializeField] private EnemyAimStateMachine _stateMachine;

		private IEnemyAimStatesRegistrar _statesRegistrar;
		private IStatesFactory _statesFactory;

		[Inject]
		public void Constructor( IStatesFactory stateFactory) => 
			_statesFactory = stateFactory;

		private void Awake()
		{
			_statesRegistrar = _stateMachine;

			RegisterEnemyStates();
		}

		private void RegisterEnemyStates()
		{
			_statesRegistrar.Clear();

			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimUpState>());
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimUpRightState>());
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimUpLeftState>());
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimRightState>());
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimLeftState>());
			_statesRegistrar.RegisterState(_statesFactory.CreateEnemyStates<EnemyAimDownState>());
		}
	}


}