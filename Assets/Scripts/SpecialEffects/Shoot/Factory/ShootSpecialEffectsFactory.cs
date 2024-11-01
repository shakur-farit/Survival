using Pool;
using UnityEngine;

namespace SpecialEffects.Factory
{
	public class ShootSpecialEffectsFactory : IShootSpecialEffectsFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected ShootSpecialEffectsFactory(IPoolFactory poolFactory) => 
			_poolFactory = poolFactory;

		public void Create(Vector2 position) => 
			_poolFactory.UseObject(PooledObjectType.ShootSpecialEffect, position);

		public void Destroy(GameObject gameObject) => 
			_poolFactory.ReturnObject(PooledObjectType.ShootSpecialEffect, gameObject);
	}
}