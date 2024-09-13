using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace SpecialEffects.Factory
{
	public class SpecialEffectsFactory : ISpecialEffectsFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected SpecialEffectsFactory(IPoolFactory poolFactory) => 
			_poolFactory = poolFactory;

		public GameObject CreateSpecialEffect(Vector2 position) => 
			_poolFactory.UseObject(PooledObjectType.SpecialEffect, position);

		public void Destroy(GameObject gameObject) => 
			_poolFactory.ReturnObject(PooledObjectType.SpecialEffect, gameObject);
	}
}