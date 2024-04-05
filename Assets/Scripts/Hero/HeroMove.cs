using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Hero
{
	public class HeroMove : MonoBehaviour
	{
		//private float _movementSpeed;

		//private InputService _inputService;
		//private StaticDataService _staticDataService;

		//private Camera _camera;

		//[Inject]
		//public void Construct(InputService inputService, StaticDataService staticDataService)
		//{
		//	_inputService = inputService;
		//	_staticDataService = staticDataService;
		//}

		//private void Start()
		//{
		//	_movementSpeed = _staticDataService.ForHero.MovementSpeed;
		//	_camera = Camera.main;
		//}

		//private void Update()
		//{
		//	if (_inputService.Axis.sqrMagnitude > 0.001f)
		//	{
		//		Vector2 movementVector = _camera.transform.TransformDirection(_inputService.Axis);

		//		transform.Translate(movementVector * (_movementSpeed * Time.deltaTime));
		//	}
		//}
	}
}
