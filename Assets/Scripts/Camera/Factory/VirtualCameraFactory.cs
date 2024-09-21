using Pool;
using UnityEngine;

namespace Camera
{
	public class VirtualCameraFactory : IVirtualCameraFactory
	{
		private GameObject _virtualCamera;

		private readonly IPoolFactory _poolFactory;

		public VirtualCameraFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() => 
			_virtualCamera = _poolFactory.UseObject(PooledObjectType.VirtualCamera);

		public void Destroy() => 
			_poolFactory.ReturnObject(PooledObjectType.VirtualCamera, _virtualCamera);
	}
}