using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Ammo.Factory
{
	public class AmmoFactory : IAmmoFactory
	{
		private readonly IPoolFactory _poolFactory;

		public AmmoFactory(IPoolFactory poolFactory) => 
			_poolFactory = poolFactory;

		public void Create(Vector2 position, Quaternion rotation) => 
			_poolFactory.UseObject(PooledObjectType.Ammo, position, rotation);

		public void Destroy(GameObject gameObject) => 
			_poolFactory.ReturnObject(PooledObjectType.Ammo, gameObject);
	}
}