using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterMover : MonoBehaviour
	{
		private float _movementSpeed;

		private InputService _inputService;
		private StaticDataService _staticDataService;

		private Camera _camera;
		private PersistentProgressService _persistentProgressService;

		[Inject]
		public void Construct(InputService inputService, StaticDataService staticDataService, PersistentProgressService persistentProgressService)
		{
			_inputService = inputService;
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		private void Start()
		{
			_movementSpeed = _staticDataService.ForCharacter.MovementSpeed;
			_camera = Camera.main;
		}

		private void Update() => 
			Move();

		private void Move()
		{
			if (_inputService.Axis.sqrMagnitude > 0.001f)
			{
				Vector2 movementVector = _camera.transform.TransformDirection(_inputService.Axis);

				transform.Translate(movementVector * (_movementSpeed * Time.deltaTime));

				_persistentProgressService.Progress.characterData.Position = transform.position;
			}
		}
	}
}
