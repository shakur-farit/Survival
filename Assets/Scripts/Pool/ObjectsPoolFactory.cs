using Cysharp.Threading.Tasks;
using StaticData;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Pool
{
	public class ObjectsPoolFactory : IObjectsPoolFactory
	{
		private Transform _poolsGroupTransform;
		private ObjectsPoolStaticData.PoolStruct _poolStruct;

		private readonly IAssetsProvider _assetsProvider;
		private readonly IStaticDataService _staticDataService;
		private readonly IObjectCreatorService _objectCreator;
		private readonly IPools _pools;

		public ObjectsPoolFactory(IAssetsProvider assetsProvider, IStaticDataService staticDataService,
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
				_poolsGroupTransform = new GameObject("Pool Group Test").transform;

			_poolStruct = InitPoolStruct(pooledObjectType);

			GameObject newObject = await CreateNewObject(_poolStruct);

			Debug.Log($"In Factory {pooledObjectType}");

			_pools.CreatePool(pooledObjectType, newObject, _poolStruct.PoolSize, _poolsGroupTransform);
		}

		public async UniTask<GameObject> UseObject(PooledObjectType pooledObjectType)
		{
			GameObject newObject = _pools.UseObject(pooledObjectType);

			if (newObject == null)
			{
				_poolStruct = InitPoolStruct(pooledObjectType);

				if (_poolStruct.CanPoolIncrease)
				{
					await CreatePool(pooledObjectType);
					newObject = _pools.UseObject(pooledObjectType);
				}
			}

			return newObject;
		}

		public async UniTask<GameObject> UseObject(PooledObjectType pooledObjectType, Vector2 position)
		{
			GameObject newObject = _pools.UseObject(pooledObjectType);

			if (newObject == null)
			{
				_poolStruct = InitPoolStruct(pooledObjectType);

				if (_poolStruct.CanPoolIncrease)
				{
					await CreatePool(pooledObjectType);
					newObject = _pools.UseObject(pooledObjectType);
				}
			}

			newObject.transform.position = position;

			return newObject;
		}

		public void ClearPools() =>
			_pools.ClearPools();

		private async UniTask<GameObject> CreateNewObject(ObjectsPoolStaticData.PoolStruct poolStruct)
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(poolStruct.PooledPrefabAddress);
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
	}
}