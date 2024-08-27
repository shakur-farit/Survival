using System;
using System.Collections.Generic;
using Character.States;
using Character.States.Motion;
using Character.States.StatesMachine.Motion;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Timer;
using UnityEngine;
using Utility;
using Zenject;

namespace Character
{
	public class CharacterMover : MonoBehaviour
	{
		[SerializeField] private CharacterAnimator CharacterAnimator;

		private float _movementSpeed;
		private bool _isMove;

		private Dictionary<Func<bool>, Action> _stateActions;

		private IMovementInputService _movementInputService;
		private IPersistentProgressService _persistentProgressService;
		private ICharacterMotionStatesSwitcher _characterMotionSwitcher;
		private IPauseService _pauseService;

		[Inject]
		public void Construct(IMovementInputService movementInputService,
			IPersistentProgressService persistentProgressService,
			ICharacterMotionStatesSwitcher characterMotionStatesSwitcher, IPauseService pauseService)
		{
			_movementInputService = movementInputService;
			_persistentProgressService = persistentProgressService;
			_characterMotionSwitcher = characterMotionStatesSwitcher;
			_pauseService = pauseService;
		}

		private void OnEnable() =>
			_movementInputService.OnEnable();

		private void OnDestroy() =>
			_movementInputService.OnDisable();

		private void Awake()
		{
			_movementInputService.RegisterMovementInputAction();
			InitializeStateActions();
		}

		private void Start()
		{
			SetupMovementSpeed();

			SwitchToIdlingState();
		}

		private void FixedUpdate() =>
			TryMove();

		private void TryMove()
		{
			if (_pauseService.IsPaused)
				return;

			Move();
		}

		private void SwitchToIdlingState() =>
			_characterMotionSwitcher.SwitchState<CharacterIdlingState>(CharacterAnimator);

		private void InitializeStateActions()
		{
			_stateActions = new Dictionary<Func<bool>, Action>
			{
				{
					() => _movementInputService.MovementAxis.sqrMagnitude > Constants.Epsilon && !_isMove,
					SwitchCharacterState<CharacterMovingState>
				},
				{
					() => _movementInputService.MovementAxis.sqrMagnitude <= Constants.Epsilon && _isMove,
					SwitchCharacterState<CharacterIdlingState>
				}
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

		private void SwitchCharacterState<T>() where T : ICharacterAnimatorState
		{
			_characterMotionSwitcher.SwitchState<T>(CharacterAnimator);
			_isMove = !_isMove;
		}

		private void SetupMovementSpeed() =>
			_movementSpeed = _persistentProgressService.Progress.CharacterData.CurrentCharacter.MovementSpeed;
	}
}