using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
	public class Pools : IPools
	{
		private readonly Dictionary<PooledObjectType, Pool> _poolsDictionary = new();

		public GameObject UseObject(PooledObjectType pooledObjectType)
		{
			if (_poolsDictionary.TryGetValue(pooledObjectType, out Pool pool))
				return pool.UseObject();

			return null;
		}

		public void ReturnObject(PooledObjectType pooledObjectType, GameObject objectToReturn)
		{
			if(_poolsDictionary.TryGetValue(pooledObjectType, out Pool pool))
				pool.ReturnObject(objectToReturn);
		}

		public void CreatePool(PooledObjectType pooledObjectType, GameObject newObject, int size, Transform poolsGroupTransform)
		{
			if (_poolsDictionary.ContainsKey(pooledObjectType) == false)
			{
				Pool pool = new Pool();

				_poolsDictionary.Add(pooledObjectType, pool);

				for (int i = 0; i < size; i++) 
					pool.AddObject(newObject, poolsGroupTransform);
			}
		}

		public void AddObject(PooledObjectType pooledObjectType, GameObject newObject) => 
			_poolsDictionary[pooledObjectType].AddObject(newObject);

		public void ClearPools() => 
			_poolsDictionary.Clear();
	}
}