using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterMover : MonoBehaviour
	{
		private float _movementSpeed;

		private Camera _camera;

		private IInputService _inputService;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Construct(IInputService inputService, IPersistentProgressService persistentProgressService)
		{
			_inputService = inputService;
			_persistentProgressService = persistentProgressService;
		}

		private void Start()
		{
			_movementSpeed = _persistentProgressService.Progress.characterData.CurrentCharacterStaticData.MovementSpeed;
			_camera = Camera.main;
		}

		private void Update() => 
			Move();

		private void Move()
		{
			if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
			{
				Vector2 movementVector = _camera.transform.TransformDirection(_inputService.Axis);

				transform.Translate(movementVector * (_movementSpeed * Time.deltaTime));
			}
		}
	}
}
