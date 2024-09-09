using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
	public class Pools : IPools
	{
		private readonly Dictionary<PooledObjectType, IPool> _poolsDictionary = new();
		
		private readonly IPool _objectsPool;

		public Pools(IPool objectsPool) => 
			_objectsPool = objectsPool;

		public GameObject UseObject(PooledObjectType pooledObjectType)
		{
			if (_poolsDictionary.TryGetValue(pooledObjectType, out IPool pool))
				return pool.UseObject();

			return null;
		}

		public void ReturnObject(PooledObjectType pooledObjectType, GameObject objectToReturn)
		{
			if(_poolsDictionary.TryGetValue(pooledObjectType, out IPool pool))
				pool.ReturnObject(objectToReturn);
		}

		public void CreatePool(PooledObjectType pooledObjectType, GameObject newObject, int size, Transform poolsGroupTransform)
		{
			Debug.Log($"In Pools {pooledObjectType}");


			if (_poolsDictionary.ContainsKey(pooledObjectType) == false)
			{
				_poolsDictionary.Add(pooledObjectType, _objectsPool);

				for (int i = 0; i < size; i++) 
					_objectsPool.AddObject(newObject, poolsGroupTransform);
			}
		}

		public void ClearPools() => 
			_poolsDictionary.Clear();
	}
}