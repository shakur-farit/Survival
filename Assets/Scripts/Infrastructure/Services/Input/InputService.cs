using UnityEngine;

namespace Infrastructure.Services.Input
{
	public abstract class InputService : IInputService
	{
		protected const string Horizontal = "Horizontal";
		protected const string Vertical = "Vertical";
		protected const string Button = "Fire";

		public abstract Vector2 Axis { get; }

		protected static Vector2 GetSimpleInputAxis() => 
			new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

		public bool IsAttackButtonUp() => SimpleInput.GetButton(Button);
	}
}