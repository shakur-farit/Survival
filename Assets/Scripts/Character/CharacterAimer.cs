using Character.States.Aim;
using Character.States.StatesMachine.Aim;
using Infrastructure.Services.Input;
using System.Collections.Generic;
using Character.States;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterAimer : MonoBehaviour
	{
		[SerializeField] private CharacterAnimator _characterAnimator;

		private IAimInputService _aimInputService;
		private ICharacterAimStatesSwitcher _characterAimStatesSwitcher;

		private Dictionary<string, AimStateInfo> _aimStates;
		private string _currentState;
		private Transform _targetTransform;

		[Inject]
		public void Constructor(IAimInputService aimInput, ICharacterAimStatesSwitcher characterAimStatesSwitcher)
		{
			_aimInputService = aimInput;
			_characterAimStatesSwitcher = characterAimStatesSwitcher;
		}

		private void OnEnable() =>
			_aimInputService.OnEnable();

		private void OnDisable() => 
			_aimInputService.OnDisable();

		private void Awake() => 
			_aimInputService.RegisterAimInputAction();

		private void Start() => 
			InitializeAimStates();

		private void FixedUpdate() => 
			Aim();

		public void SetTarget(Transform target) =>
			_targetTransform = target;

		public void ClearTarget() =>
			_targetTransform = null;

		private void InitializeAimStates()
		{
			_aimStates = new Dictionary<string, AimStateInfo>
			{
				{ "Up", CreateAimStateInfo<CharacterAimUpState>("Up", 67f, 90f) },
				{ "UpLeft", CreateAimStateInfo<CharacterAimUpLeftState>("UpLeft", 115f, 140f) },
				{ "UpRight", CreateAimStateInfo<CharacterAimUpRightState>("UpRight", 22f, 67f) },
				{ "Left", CreateAimStateInfo<CharacterAimLeftState>("Left", 158f, 180f) },
				{ "LeftNegative", CreateAimStateInfo<CharacterAimLeftState>("Left", -180f, -136f) },
				{ "Down", CreateAimStateInfo<CharacterAimDownState>("Down", -115f, -46f) },
				{ "Right", CreateAimStateInfo<CharacterAimRightState>("Right", -45f, 0f) },
				{ "RightPositive", CreateAimStateInfo<CharacterAimRightState>("Right", 0f, 21f) }
			};
		}

		private AimStateInfo CreateAimStateInfo<TState>(string stateName, float minAngle, float maxAngle) where TState : ICharacterAnimatorState
		{
			return new AimStateInfo
			{
				StateName = stateName,
				MinAngle = minAngle,
				MaxAngle = maxAngle,
				SwitchStateAction = () => SwitchState<TState>(stateName)
			};
		}

		private void SwitchState<TState>(string stateName) where TState : ICharacterAnimatorState
		{
			_characterAimStatesSwitcher.SwitchState<TState>(_characterAnimator);
			_currentState = stateName;
		}

		private void Aim()
		{
			float angleDegree = 0f;

			if (_targetTransform == null)
			{
				transform.rotation = Quaternion.AngleAxis(angleDegree, Vector3.forward);
				return;
			}

			Vector2 direction = _targetTransform.position - transform.position;
			angleDegree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			transform.rotation = Quaternion.AngleAxis(angleDegree, Vector3.forward);

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
	}
}
