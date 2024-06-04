using System.Collections.Generic;
using EnemyLogic.Mediator;
using EnemyLogic.States;
using Infrastructure.Services.Factories.Character;
using StaticData;
using UnityEngine;
using Zenject;
using EnemyLogic.States.StateMachine;

namespace EnemyLogic
{
	public class EnemyMover : MonoBehaviour
	{
		private float _movementSpeed;
		private GameObject _target;

		private ICharacterFactory _characterFactory;
		private IEnemySpeedMediator _speedMediator;

		private Dictionary<string, AimStateInfo> _aimStates;
		private IEnemyAimStatesSwitcher _statesSwitcher;
		private EnemyAnimator _enemyAnimator;
		private string _currentState;

		[Inject]
		public void Constructor(ICharacterFactory characterFactory, IEnemySpeedMediator mediator, IEnemyAimStatesSwitcher statesSwitcher)
		{
			_characterFactory = characterFactory;
			_speedMediator = mediator;
			_statesSwitcher = statesSwitcher;
		}

		private void Awake()
		{
			_speedMediator.RegisterMover(this);
			_target = _characterFactory.Character;
			_enemyAnimator = gameObject.GetComponent<EnemyAnimator>();
			InitializeAimStates();
		}

		private void Update() => 
			Move();

		public void SetupSpeed(EnemyStaticData staticData) => 
			_movementSpeed = staticData.MovementSpeed;

		private void Move()
		{
			if (_target == null)
				return;

			Vector2 targetPosition = _target.transform.position;
			Vector2 enemyPosition = transform.position;

			Vector2 direction = targetPosition - enemyPosition;
			direction.Normalize();

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			//Debug.Log(angle);

			enemyPosition = Vector2.MoveTowards(enemyPosition,
				targetPosition, _movementSpeed * Time.deltaTime);

			transform.position = enemyPosition;
			//transform.rotation = Quaternion.Euler(Vector3.forward * angle);

			EnterInSuitableState(angle);
		}

		private void InitializeAimStates()
		{
			_aimStates = new Dictionary<string, AimStateInfo>
			{
				{ "Up", CreateAimStateInfo<EnemyAimUpState>("Up", 67f, 112f) },
				{ "UpLeft", CreateAimStateInfo<EnemyAimUpLeftState>("UpLeft", 112f, 158f) },
				{ "UpRight", CreateAimStateInfo<EnemyAimUpRightState>("UpRight", 22f, 67f) },
				{ "Left", CreateAimStateInfo<EnemyAimLeftState>("Left", 158f, 180f) },
				{ "LeftNegative", CreateAimStateInfo<EnemyAimLeftState>("Left", -180f, -135f) },
				{ "Down", CreateAimStateInfo<EnemyAimDownState>("Down", -135f, -45f) },
				{ "Right", CreateAimStateInfo<EnemyAimRightState>("Right", -45f, 0f) },
				{ "RightPositive", CreateAimStateInfo<EnemyAimRightState>("Right", 0f, 22f) }
			};
		}

		private AimStateInfo CreateAimStateInfo<TState>(string stateName, float minAngle, float maxAngle) where TState : IEnemyAnimatorState
		{
			return new AimStateInfo
			{
				StateName = stateName,
				MinAngle = minAngle,
				MaxAngle = maxAngle,
				SwitchStateAction = () => SwitchState<TState>(stateName)
			};
		}

		private void SwitchState<TState>(string stateName) where TState : IEnemyAnimatorState
		{
			_statesSwitcher.SwitchState<TState>(_enemyAnimator);
			_currentState = stateName;
		}

		private void EnterInSuitableState(float angleDegree)
		{
			foreach (var stateInfo in _aimStates.Values)
			{
				if (IsInAngleRange(angleDegree, stateInfo.MinAngle, stateInfo.MaxAngle) && _currentState != stateInfo.StateName)
				{
					stateInfo.SwitchStateAction();
					break;
				}
			}
		}

		private bool IsInAngleRange(float angle, float min, float max)
		{
			if (min < max)
				return angle >= min && angle <= max;

			return angle >= min || angle <= max;
		}
	}
}
