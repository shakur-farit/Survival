using System;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterMover : MonoBehaviour
	{
		private float _movementSpeed;

		private IMovementInputService _movementInputService;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Construct(IMovementInputService movementInputService, IPersistentProgressService persistentProgressService)
		{
			_movementInputService = movementInputService;
			_persistentProgressService = persistentProgressService;
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
			}
		}

		private void SetupMovementSpeed() => 
			_movementSpeed = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData.MovementSpeed;
	}
}
