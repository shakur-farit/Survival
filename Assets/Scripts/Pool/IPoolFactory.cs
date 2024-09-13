using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Pool
{
	public interface IPoolFactory
	{
		UniTask CreatePool(PooledObjectType pooledObjectType);
		
		GameObject UseObject(PooledObjectType pooledObjectType);
		GameObject UseObject(PooledObjectType pooledObjectType, Vector2 position);
		GameObject UseObject(PooledObjectType pooledObjectType, Vector2 position, Quaternion rotation);
		GameObject UseObject(PooledObjectType pooledObjectType, Transform parentTransform);

		void ClearPools();
		void ReturnObject(PooledObjectType pooledObjectType, GameObject objectToReturn);
	}
}