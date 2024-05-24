using UnityEngine;

namespace Infrastructure.Services.Input
{
	public class InputService : IInputService
	{
		private const string Horizontal = "Horizontal";
		private const string Vertical = "Vertical";

		public  Vector2 Axis => GetSimpleInputAxis();

		private static Vector2 GetSimpleInputAxis() => 
			new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
	}
}