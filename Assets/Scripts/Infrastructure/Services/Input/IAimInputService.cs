using UnityEngine;

namespace Infrastructure.Services.Input
{
	public interface IAimInputService
	{
		Vector2 AimAxis { get; }

		void OnEnable();
		void OnDisable();
		void RegisterAimInputAction();
	}
}