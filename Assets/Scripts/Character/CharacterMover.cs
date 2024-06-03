using System;
using System.Collections.Generic;
using Character.States;
using Character.States.Motion;
using Character.States.StatesMachine.Motion;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Utility;
using Zenject;

namespace Character
{
	public class CharacterMover : MonoBehaviour
	{
		private float _movementSpeed;
		private bool _isMove;

		private IMovementInputService _movementInputService;
		private IPersistentProgressService _persistentProgressService;
		private ICharacterMotionStatesSwitcher _characterMotionSwitcher;

		private Dictionary<Func<bool>, Action> _stateActions;

		[Inject]
		public void Construct(IMovementInputService movementInputService, IPersistentProgressService persistentProgressService,
				ICharacterMotionStatesSwitcher characterMotionStatesSwitcher)
		{
			_movementInputService = movementInputService;
			_persistentProgressService = persistentProgressService;
			_characterMotionSwitcher = characterMotionStatesSwitcher;
		}

		private void OnEnable() => 
			_movementInputService.OnEnable();

		private void OnDestroy() => 
			_movementInputService.OnDisable();

		private void Awake() => 
			_movementInputService.RegisterMovementInputAction();

		private void Start()
		{
			SetupMovementSpeed();

			InitializeStateActions();
		}

		private void FixedUpdate() => 
			Move();

		private void InitializeStateActions()
		{
			_stateActions = new Dictionary<Func<bool>, Action>
			{
				{ () => _movementInputService.MovementAxis.sqrMagnitude > Constants.Epsilon && !_isMove, 
					SwitchCharacterState<MovingState> },
				{ () => _movementInputService.MovementAxis.sqrMagnitude <= Constants.Epsilon && _isMove, 
					SwitchCharacterState<IdlingState> }
			};
		}

		private void Move()
		{
			Vector2 movementAxis = _movementInputService.MovementAxis;

			if (movementAxis.sqrMagnitude > Constants.Epsilon)
			{
				Vector2 movementVector = transform.TransformDirection(movementAxis);
				movementVector.Normalize();
				transform.Translate(movementVector * (_movementSpeed * Time.deltaTime));
			}

			foreach (KeyValuePair<Func<bool>, Action> stateAction in _stateActions)
			{
				if (stateAction.Key.Invoke())
				{
					stateAction.Value.Invoke();
					break;
				}
			}
		}

		private void SwitchCharacterState<T>() where T : CharacterState
		{
			_characterMotionSwitcher.SwitchState<T>();
			_isMove = !_isMove;
		}

		private void SetupMovementSpeed() =>
				_movementSpeed = _persistentProgressService.Progress.CharacterData.CurrentCharacter.MovementSpeed;
	}
}
