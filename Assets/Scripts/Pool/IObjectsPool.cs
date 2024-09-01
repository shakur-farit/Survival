using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Pool
{
	public interface IObjectsPool
	{
		UniTask CreatePool(PooledObjectType pooledObjectType);
		UniTask<GameObject> UseObject(PooledObjectType pooledObjectType, Vector2 position = default, Quaternion rotation = default);
		void ReturnObject(PooledObjectType pooledObjectType, GameObject objectToReturn);
	}
}