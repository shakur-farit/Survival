using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Input
{
	public class InputService : IMovementInputService, IFireInputService
	{
		private readonly CharacterInput _input;

		private InputAction _moveAction;
		private InputAction _fireAction;

		private Vector2 _moveInput;
		private bool _isFireButtonPressed;

		public  Vector2 MovementAxis => GetMovementInputAxis();
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

		public void RegisterFireInputAction()
		{
			_fireAction = _input.Player.Fire;
			_fireAction.performed += context => _isFireButtonPressed = context.performed;
			_fireAction.canceled += context => _isFireButtonPressed = false;
		}

		private Vector2 GetMovementInputAxis() => 
			new(_moveInput.x, _moveInput.y);
	}
}