using Pool;
using UnityEngine;

namespace Effects.SpecialEffects.Shot.Factory
{
	public class ShootSpecialEffectsFactory : IShootSpecialEffectsFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected ShootSpecialEffectsFactory(IPoolFactory poolFactory) => 
			_poolFactory = poolFactory;

		public void Create(Vector2 position) => 
			_poolFactory.UseObject(PooledObjectType.ShotSpecialEffect, position);

		public void Destroy(GameObject gameObject) => 
			_poolFactory.ReturnObject(PooledObjectType.ShotSpecialEffect, gameObject);
	}
}