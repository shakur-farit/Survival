using UnityEngine;

namespace Pool
{
	public interface IPools
	{
		GameObject UseObject(PooledObjectType pooledObjectType);
		void ReturnObject(PooledObjectType pooledObjectType, GameObject objectToReturn);
		void CreatePool(PooledObjectType type, GameObject newObject, int size, Transform poolsGroupTransform);
		void ClearPools();
	}
}