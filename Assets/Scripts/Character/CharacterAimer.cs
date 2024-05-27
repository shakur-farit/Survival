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
		private bool _isDown;

		[Inject]
		public void Constructor(IAimInputService aimInput, ICharacterAimEvent characterAimEvent)
		{
			_aimInputService = aimInput;
			_characterAimEvent = characterAimEvent;
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

			float angleRadians = Mathf.Atan2(aimVector.y, aimVector.x);
			float angleDegree = angleRadians * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angleDegree, Vector3.forward);

			if (angleDegree < 0 && _isDown)
			{
				_characterAimEvent.CallCharacterAimSwitchedEvent();
				_isDown = !_isDown;
			}

			if (angleDegree > 0 && _isDown == false)
			{
				_characterAimEvent.CallCharacterAimSwitchedEvent();
				_isDown = !_isDown;
			}
		}
	}
}