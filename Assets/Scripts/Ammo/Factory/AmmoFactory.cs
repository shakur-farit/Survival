using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Ammo.Factory
{
	public class AmmoFactory : IAmmoFactory
	{
		private readonly IObjectsPool _objectsPool;

		public AmmoFactory(IObjectsPool objectsPool) => 
			_objectsPool = objectsPool;

		public async UniTask Create(Vector2 position, Quaternion rotation) => 
			await _objectsPool.UseObject(PooledObjectType.Ammo, position, rotation);

		public void Destroy(GameObject gameObject) => 
			_objectsPool.ReturnObject(PooledObjectType.Ammo, gameObject);
	}
}