using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using StaticData;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using Infrastructure.Services.StaticData;
using UnityEngine;
using UnityEngine.UIElements;

namespace Pool
{
	public class PoolFactory : IPoolFactory
	{
		private readonly Dictionary<PooledObjectType, GameObject> _prefabs = new();

		private Transform _poolsGroupTransform;
		private ObjectsPoolStaticData.PoolStruct _poolStruct;

		private readonly IAssetsProvider _assetsProvider;
		private readonly IStaticDataService _staticDataService;
		private readonly IObjectCreatorService _objectCreator;
		private readonly IPools _pools;

		public PoolFactory(IAssetsProvider assetsProvider, IStaticDataService staticDataService,
			IObjectCreatorService objectCreator, IPools pools)
		{
			_assetsProvider = assetsProvider;
			_staticDataService = staticDataService;
			_objectCreator = objectCreator;
			_pools = pools;
		}

		public async UniTask CreatePool(PooledObjectType pooledObjectType)
		{
			if (_poolsGroupTransform == null)
				_poolsGroupTransform = new GameObject("Pool Group").transform;

			_poolStruct = InitPoolStruct(pooledObjectType);

			_prefabs[pooledObjectType] = await _assetsProvider.Load<GameObject>(_poolStruct.PooledPrefabAddress);

			Debug.Log($"{_prefabs.Count} / {_prefabs[pooledObjectType].name}");

			for (int i = 0; i < _poolStruct.PoolSize; i++)
			{
				GameObject newObject = CreateNewObject(_prefabs[pooledObjectType]);
				_pools.CreatePool(pooledObjectType, newObject, _poolsGroupTransform);
			}
		}

		public GameObject UseObject(PooledObjectType pooledObjectType)
		{
			GameObject newObject = _pools.UseObject(pooledObjectType);

			if (newObject == null) 
				newObject = TryIncreasePool(pooledObjectType);

			return newObject;
		}

		public GameObject UseObject(PooledObjectType pooledObjectType, Vector2 position)
		{
			GameObject newObject = _pools.UseObject(pooledObjectType);

			if (newObject == null)
				newObject = TryIncreasePool(pooledObjectType);

			newObject.transform.position = position;

			return newObject;
		}

		public GameObject UseObject(PooledObjectType pooledObjectType, Vector2 position, Quaternion rotation)
		{
			GameObject newObject = _pools.UseObject(pooledObjectType);

			if (newObject == null)
				newObject = TryIncreasePool(pooledObjectType);

			newObject.transform.position = position;
			newObject.transform.rotation = rotation;

			return newObject;
		}

		public GameObject UseObject(PooledObjectType pooledObjectType, Transform parentTransform)
		{
			GameObject newObject = _pools.UseObject(pooledObjectType);

			if (newObject == null)
				newObject = TryIncreasePool(pooledObjectType);

			newObject.transform.SetParent(parentTransform);
			
			return newObject;
		}

		public void ReturnObject(PooledObjectType pooledObjectType, GameObject objectToReturn) => 
			_pools.ReturnObject(pooledObjectType, objectToReturn);

		public void ClearPools() =>
			_pools.ClearPools();

		private GameObject CreateNewObject(GameObject prefab)
		{
			GameObject newObject = _objectCreator.Instantiate(prefab);
			return newObject;
		}

		private ObjectsPoolStaticData.PoolStruct InitPoolStruct(PooledObjectType pooledObjectType)
		{
			foreach (ObjectsPoolStaticData.PoolStruct poolStruct in _staticDataService.ObjectsPoolStaticData.PoolsList)
				if (pooledObjectType == poolStruct.pooledObjectType)
					return poolStruct;

			return null;
		}

		private GameObject TryIncreasePool(PooledObjectType pooledObjectType)
		{
			GameObject newObject;
			_poolStruct = InitPoolStruct(pooledObjectType);

			if (_poolStruct.CanPoolIncrease && _prefabs[pooledObjectType] != null)
			{
				newObject = CreateNewObject(_prefabs[pooledObjectType]);

				_pools.AddObject(pooledObjectType, newObject, null);
			}

			newObject = _pools.UseObject(pooledObjectType);
			return newObject;
		}
	}
}