using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Input
{
	public class InputService : IInputService
	{
		private const string Horizontal = "Horizontal";
		private const string Vertical = "Vertical";
		private Vector2 _moveVector;

		public  Vector2 Axis => GetSimpleInputAxis();

		private Vector2 GetSimpleInputAxis()
		{
			//return new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
			return default; //new Vector2(_moveVector.x, _moveVector.y);
		}

		
	}
}