using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace SpecialEffects.Factory
{
	public class SpecialEffectsFactory : ISpecialEffectsFactory
	{
		private readonly IObjectsPool _objectsPool;

		protected SpecialEffectsFactory(IObjectsPool objectsPool) => 
			_objectsPool = objectsPool;

		public async UniTask<GameObject> CreateSpecialEffect(Vector2 position) => 
			await _objectsPool.UseObject(PooledObjectType.SpecialEffect, position);

		public void Destroy(GameObject gameObject) => 
			_objectsPool.ReturnObject(PooledObjectType.SpecialEffect, gameObject);
	}
}