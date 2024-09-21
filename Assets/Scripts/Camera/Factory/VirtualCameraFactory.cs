using Pool;

namespace Camera
{
	public class VirtualCameraFactory : IVirtualCameraFactory
	{
		private readonly IPoolFactory _poolFactory;

		public VirtualCameraFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() =>
			_poolFactory.UseObject(PooledObjectType.VirtualCamera);
	}
}