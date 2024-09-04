using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Pool
{
	public interface IObjectsPool
	{
		UniTask CreatePool(PooledObjectType pooledObjectType);
		UniTask<GameObject> UseObject(PooledObjectType pooledObjectType);
		UniTask<GameObject> UseObject(PooledObjectType pooledObjectType, Vector2 position);
		UniTask<GameObject> UseObject(PooledObjectType pooledObjectType, Vector2 position, Quaternion rotation); 
		UniTask<GameObject> UseObject(PooledObjectType pooledObjectType, Transform parentTransform); 
		void ReturnObject(PooledObjectType pooledObjectType, GameObject objectToReturn);
		void ClearDictionaries();
	}
}