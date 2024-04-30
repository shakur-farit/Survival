using UnityEngine;

namespace Infrastructure.Services.Input
{
	public class InputService : IInputService
	{
		private const string Horizontal = "Horizontal";
		private const string Vertical = "Vertical";
		private const string Button = "Fire";

		public  Vector2 Axis => GetSimpleInputAxis();

		public bool IsAttackButtonUp() => SimpleInput.GetButton(Button);

		private static Vector2 GetSimpleInputAxis() => 
			new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
	}
}