using System;
using System.Collections.Generic;
using Enemy.States;
using Enemy.States.StateMachine;
using UnityEngine;

namespace Enemy
{
	public class EnemyAimer : MonoBehaviour
	{
		[SerializeField] private EnemyAnimator _enemyAnimator;
		[SerializeField] private EnemyAimStateMachine _stateMachine;

		private Dictionary<string, AimStateInfo> _aimStates;
		private string _currentState;

		private IEnemyAimStatesSwitcher _statesSwitcher;

		private void Awake()
		{
			_statesSwitcher = _stateMachine;

			InitializeAimStates();
		}

		private void OnEnable() => 
			_currentState = string.Empty;

		public void Aim(float angleDegree)
		{
			transform.rotation = Quaternion.Euler(Vector3.forward * angleDegree);
			EnterInSuitableState(angleDegree);
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
	}
}