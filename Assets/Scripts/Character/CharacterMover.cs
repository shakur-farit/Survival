using System;
using Events;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterMover : MonoBehaviour
	{
		private float _movementSpeed;
		private bool _isMove;

		private IMovementInputService _movementInputService;
		private IPersistentProgressService _persistentProgressService;
		private ICharacterMotionEvent _characterMotionEvent;

		[Inject]
		public void Construct(IMovementInputService movementInputService, IPersistentProgressService persistentProgressService,
			ICharacterMotionEvent characterMotionEvent)
		{
			_movementInputService = movementInputService;
			_persistentProgressService = persistentProgressService;
			_characterMotionEvent = characterMotionEvent;
		}

		private void OnEnable() =>
			_movementInputService.OnEnable();

		private void OnDestroy() =>
			_movementInputService.OnDisable();

		private void Awake() => 
			_movementInputService.RegisterMovementInputAction();

		private void Start() => 
			SetupMovementSpeed();

		private void FixedUpdate() => 
			Move();

		private void Move()
		{
			if (_movementInputService.MovementAxis.sqrMagnitude > Constants.Epsilon)
			{
				Vector2 movementVector = transform.TransformDirection(_movementInputService.MovementAxis);
				movementVector.Normalize();
				transform.Translate(new Vector2(movementVector.x, movementVector.y) * (_movementSpeed * Time.deltaTime));

				if(_isMove == false)
					SwitchCharacterState();
			}
			else
			{
				if(_isMove)
					SwitchCharacterState();
			}
		}

		private void SwitchCharacterState()
		{
			_characterMotionEvent.CallCharacterMotionSwitchedEvent();
			_isMove = !_isMove;
		}

		private void SetupMovementSpeed() => 
			_movementSpeed = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData.MovementSpeed;
	}
}
