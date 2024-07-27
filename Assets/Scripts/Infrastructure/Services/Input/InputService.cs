using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Input
{
	public class InputService : IMovementInputService, IAimInputService, IFireInputService
	{
		private readonly CharacterInput _input;

		private InputAction _moveAction;
		private InputAction _aimAction;
		private InputAction _fireAction;

		private Vector2 _moveInput;
		private Vector2 _aimInput;
		private bool _isFireButtonPressed;

		public  Vector2 MovementAxis => GetMovementInputAxis();
		public Vector2 AimAxis => GetAimInputAxis();
		public bool IsFireButtonPressed => _isFireButtonPressed;

		public InputService(CharacterInput input) => 
			_input = input;

		public void OnEnable() => 
			_input.Enable();

		public void OnDisable() => 
			_input.Disable();

		public void RegisterMovementInputAction()
		{
			_moveAction = _input.Player.Move;

			_moveAction.performed += context => _moveInput = context.ReadValue<Vector2>();
			_moveAction.canceled += context => _moveInput = Vector2.zero;
		}

		public void RegisterAimInputAction()
		{
			_aimAction = _input.Player.Aim;

			_aimAction.performed += context => _aimInput = context.ReadValue<Vector2>();
			_aimAction.canceled += context => _aimInput = Vector2.zero;
		}

		public void RegisterFireInputAction()
		{
			_fireAction = _input.Player.Fire;
			_fireAction.performed += context => _isFireButtonPressed = context.performed;
			_fireAction.canceled += context => _isFireButtonPressed = false;
		}

		private Vector2 GetMovementInputAxis() => 
			new(_moveInput.x, _moveInput.y);

		public Vector2 GetAimInputAxis() => 
			new(_aimInput.x, _aimInput.y);
	}
}