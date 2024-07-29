using Character.States.Aim;
using Character.States.StatesMachine.Aim;
using Infrastructure.Services.Input;
using System.Collections.Generic;
using Character.States;
using UnityEngine;
using Utility;
using Zenject;

namespace Character
{
	public class CharacterAimer : MonoBehaviour
	{
		[SerializeField] private Transform _characterTransform;
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
				{ "Up", CreateAimStateInfo<CharacterAimUpState>("Up", Constants.UpAndUpRightBorder, Constants.UpAndUpLeftBorder) },
				{ "UpLeft", CreateAimStateInfo<CharacterAimUpLeftState>("UpLeft", Constants.UpAndUpLeftBorder, Constants.LeftAndUpLeftBorder) },
				{ "UpRight", CreateAimStateInfo<CharacterAimUpRightState>("UpRight", Constants.RightAndUpRightBorder, Constants.UpAndUpRightBorder) },
				{ "Left", CreateAimStateInfo<CharacterAimLeftState>("Left", Constants.LeftAndUpLeftBorder, Constants.LeftPositiveBorder) },
				{ "LeftNegative", CreateAimStateInfo<CharacterAimLeftState>("Left", Constants.LeftNegativeBorder, Constants.LeftAndDownBorder) },
				{ "Down", CreateAimStateInfo<CharacterAimDownState>("Down", Constants.LeftAndDownBorder, Constants.RightAndDownBorder) },
				{ "Right", CreateAimStateInfo<CharacterAimRightState>("Right", Constants.RightAndDownBorder, Constants.RightNegativeBorder) },
				{ "RightPositive", CreateAimStateInfo<CharacterAimRightState>("Right", Constants.RightNegativeBorder, Constants.RightAndUpRightBorder) }
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
				EnterInSuitableState(angleDegree);
				return;
			}

			Vector2 direction = _targetTransform.position - _characterTransform.position;
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
