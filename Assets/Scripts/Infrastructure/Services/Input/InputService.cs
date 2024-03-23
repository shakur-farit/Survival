using UnityEngine;

namespace Infrastructure.Services.Input
{
	public class InputService
	{
		protected const string Horizontal = "Horizontal";
		protected const string Vertical = "Vertical";
		protected const string Button = "Fire";

		public  Vector2 Axis => GetSimpleInputAxis();

		protected static Vector2 GetSimpleInputAxis() => 
			new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

		public bool IsAttackButtonUp() => SimpleInput.GetButton(Button);

	}
}