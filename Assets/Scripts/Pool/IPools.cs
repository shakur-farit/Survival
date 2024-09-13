using UnityEngine;

namespace Pool
{
	public interface IPools
	{
		GameObject UseObject(PooledObjectType pooledObjectType);
		void ReturnObject(PooledObjectType pooledObjectType, GameObject objectToReturn);
		void CreatePool(PooledObjectType type, GameObject newObject, Transform poolsGroupTransform);
		void AddObject(PooledObjectType pooledObjectType, GameObject newObject, Transform poolsGroupTransform);
		void ClearPools();
	}
}