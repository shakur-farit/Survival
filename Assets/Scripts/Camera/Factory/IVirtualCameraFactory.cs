using UnityEngine;

namespace Camera
{
	public interface IVirtualCameraFactory
	{
		void Create();
		void Destroy();
	}
}