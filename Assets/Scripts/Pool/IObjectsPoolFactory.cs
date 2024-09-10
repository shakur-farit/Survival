using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Pool
{
	public interface IObjectsPoolFactory
	{
		UniTask CreatePool(PooledObjectType pooledObjectType);
		UniTask<GameObject> UseObject(PooledObjectType pooledObjectType);
		UniTask<GameObject> UseObject(PooledObjectType pooledObjectType, Vector2 position);
		void ClearPools();
	}
}