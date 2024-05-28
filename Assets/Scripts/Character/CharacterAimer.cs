using Character.States.Aim;
using Character.States.StatesMachine.Aim;
using Events;
using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterAimer : MonoBehaviour
	{
		private IAimInputService _aimInputService;
		private ICharacterAimEvent _characterAimEvent;
		private ICharacterAimStatesSwitcher _characterAimStatesSwitcher;

		private bool _isDown;
		private bool _isUp;
		private bool _isLeft;
		private bool _isRight;

		private float _angleDegree;

		private bool AimUp => _angleDegree > 80 && _angleDegree < 110;
		private bool AimRight => (_angleDegree > -160 && _angleDegree < -20);
		private bool AimLeft => _angleDegree > 110 && _angleDegree < 230;
		private bool AimDown => _angleDegree > -160 && _angleDegree < -20;

		[Inject]
		public void Constructor(IAimInputService aimInput, ICharacterAimEvent characterAimEvent, ICharacterAimStatesSwitcher characterAimStatesSwitcher)
		{
			_aimInputService = aimInput;
			_characterAimEvent = characterAimEvent;
			_characterAimStatesSwitcher = characterAimStatesSwitcher;
		}

		private void OnEnable() => 
			_aimInputService.OnEnable();

		private void OnDisable() => 
			_aimInputService.OnDisable();

		private void Awake() => 
			_aimInputService.RegisterAimInputAction();

		private void FixedUpdate() => 
			Aim();

		private void Aim()
		{
			Vector2 aimVector = _aimInputService.AimAxis;

			_angleDegree = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(_angleDegree, Vector3.forward);

			EnterInSuitableState();
		}

		private void EnterInSuitableState()
		{
			if (AimUp && _isUp == false)
				SwitchAimState<AimUpState>(ref _isUp);
			else if (AimLeft && _isLeft == false)
				SwitchAimState<AimLeftState>(ref _isLeft);
			else if (AimDown && _isDown == false)
				SwitchAimState<AimDownState>(ref _isDown);
			else if (AimRight && _isRight == false)
				SwitchAimState<AimRightState>(ref _isRight);
		}

		private void SwitchAimState<T>(ref bool directionFlag) where T : AimState
		{
			_characterAimStatesSwitcher.SwitchState<T>();
			ResetFlags();
			directionFlag = true;
		}

		private void ResetFlags()
		{
			_isUp = false;
			_isDown = false;
			_isLeft = false;
			_isRight = false;
		}
	}
}