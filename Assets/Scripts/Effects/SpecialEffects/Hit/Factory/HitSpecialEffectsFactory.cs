using Pool;
using UnityEngine;

namespace Effects.SpecialEffects.Hit.Factory
{
	public class HitSpecialEffectsFactory : IHitSpecialEffectsFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected HitSpecialEffectsFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create(Vector2 position) => 
			_poolFactory.UseObject(PooledObjectType.HitSpecialEffect, position);

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.HitSpecialEffect, gameObject);
	}
}