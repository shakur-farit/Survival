using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Hero
{
	public class HeroMove : MonoBehaviour
	{
		public float MovementSpeed;

		private InputService _inputService;
		private Camera _camera;

		[Inject]
		private void Construct(InputService inputService) => 
			_inputService = inputService;

		private void Start() => 
			_camera = Camera.main;

		private void Update()
		{
			Vector2 movementVector = Vector2.zero;

			if (_inputService.Axis.sqrMagnitude > 0.001f)
			{
				movementVector = _camera.transform.TransformDirection(_inputService.Axis);
				//movementVector.Normalize();

				transform.Translate(movementVector * (MovementSpeed * Time.deltaTime));

				//transform.forward = movementVector;
			}
		}
	}
}
