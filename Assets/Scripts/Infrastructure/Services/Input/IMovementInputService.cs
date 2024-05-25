using UnityEngine;

namespace Infrastructure.Services.Input
{
	public interface IMovementInputService
	{
		Vector2 MovementAxis { get; }

		void OnEnable();
		void OnDisable();
		void RegisterMovementInputAction();
	}
}