using Character.States.Aim;
using Character.States.StatesMachine.Aim;
using Infrastructure.Services.Input;
using System.Collections.Generic;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterAimer : MonoBehaviour
	{
		private IAimInputService _aimInputService;
		private ICharacterAimStatesSwitcher _characterAimStatesSwitcher;

		private float _angleDegree;

		private Dictionary<string, AimStateInfo> _aimStates;
		private string _currentState;

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

		private void FixedUpdate() => Aim();

		private void InitializeAimStates()
		{
			_aimStates = new Dictionary<string, AimStateInfo>
			{
				{ "Up", CreateAimStateInfo<AimUpState>("Up", 67f, 112f) },
				{ "UpLeft", CreateAimStateInfo<AimUpLeftState>("UpLeft", 112f, 158f) },
				{ "UpRight", CreateAimStateInfo<AimUpRightState>("UpRight", 22f, 67f) },
				{ "Left", CreateAimStateInfo<AimLeftState>("Left", 158f, 180f) },
				{ "LeftNegative", CreateAimStateInfo<AimLeftState>("Left", -180f, -135f) },
				{ "Down", CreateAimStateInfo<AimDownState>("Down", -135f, -45f) },
				{ "Right", CreateAimStateInfo<AimRightState>("Right", -45f, 0f) },
				{ "RightPositive", CreateAimStateInfo<AimRightState>("Right", 0f, 22f) }
			};
		}

		private AimStateInfo CreateAimStateInfo<TState>(string stateName, float minAngle, float maxAngle) where TState : IState
		{
			return new AimStateInfo
			{
				StateName = stateName,
				MinAngle = minAngle,
				MaxAngle = maxAngle,
				SwitchStateAction = () => SwitchState<TState>(stateName)
			};
		}

		private void SwitchState<TState>(string stateName) where TState : IState
		{
			_characterAimStatesSwitcher.SwitchState<TState>();
			_currentState = stateName;
		}

		private void Aim()
		{
			Vector2 aimVector = _aimInputService.AimAxis;
			_angleDegree = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(_angleDegree, Vector3.forward);

			EnterInSuitableState();
		}

		private void EnterInSuitableState()
		{
			foreach (var stateInfo in _aimStates.Values)
			{
				if (IsInAngleRange(_angleDegree, stateInfo.MinAngle, stateInfo.MaxAngle) && _currentState != stateInfo.StateName)
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
