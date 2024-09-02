using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;

namespace Pool
{
	public class ObjectsPool : IObjectsPool
	{
		private Transform _objectPoolTransform;

		private readonly Dictionary<PooledObjectType, Queue<GameObject>> _poolDictionary = new();
		private readonly Dictionary<PooledObjectType, Transform> _parents = new();

		private Transform _parentTransform;

		private readonly IObjectCreatorService _objectCreator;
		private readonly IAssetsProvider _assetsProvider;
		private readonly IStaticDataService _staticDataService;

		public ObjectsPool(IObjectCreatorService objectCreator, IAssetsProvider assetsProvider,
			IStaticDataService staticDataService)
		{
			_objectCreator = objectCreator;
			_assetsProvider = assetsProvider;
			_staticDataService = staticDataService;
		}

		public async UniTask CreatePool(PooledObjectType pooledObjectType)
		{
			if (_objectPoolTransform == null) 
				_objectPoolTransform = new GameObject("Pool Group").transform;

			ObjectsPoolStaticData.PoolStruct poolStruct = InitPoolStruct(pooledObjectType);

			GameObject prefab = await _assetsProvider.Load<GameObject>(poolStruct.PooledPrefabAddress);

			string prefabName = prefab.name;

			if (_poolDictionary.ContainsKey(pooledObjectType) == false)
			{
				_parentTransform = new GameObject(prefabName + "Anchor").transform;

				_parents.Add(pooledObjectType, _parentTransform);
				_poolDictionary.Add(pooledObjectType, new Queue<GameObject>());

				_parentTransform.transform.SetParent(_objectPoolTransform);
			}

			if (pooledObjectType == poolStruct.pooledObjectType)
				for (int i = 0; i < poolStruct.PoolSize; i++)
					CreateNewObject(pooledObjectType, prefab);
		}

		public async UniTask<GameObject> UseObject(PooledObjectType pooledObjectType)
		{
			if (_poolDictionary.ContainsKey(pooledObjectType) == false || _poolDictionary[pooledObjectType].Count <= 0)
			{
				ObjectsPoolStaticData.PoolStruct poolStruct = InitPoolStruct(pooledObjectType);

				if (poolStruct.CanPoolIncrease) 
					await CreatePool(pooledObjectType);
			}

			GameObject objectToUse = _poolDictionary[pooledObjectType].Dequeue();
			objectToUse.SetActive(true);
			return objectToUse;
		}

		public async UniTask<GameObject> UseObject(PooledObjectType pooledObjectType, Vector2 position)
		{
			if (_poolDictionary.ContainsKey(pooledObjectType) == false || _poolDictionary[pooledObjectType].Count <= 0)
			{
				ObjectsPoolStaticData.PoolStruct poolStruct = InitPoolStruct(pooledObjectType);

				if (poolStruct.CanPoolIncrease)
					await CreatePool(pooledObjectType);
			}

			GameObject objectToUse = _poolDictionary[pooledObjectType].Dequeue();
			objectToUse.transform.position = position;
			objectToUse.SetActive(true);
			return objectToUse;
		}

		public async UniTask<GameObject> UseObject(PooledObjectType pooledObjectType,
			Vector2 position, Quaternion rotation)
		{
			if (_poolDictionary.ContainsKey(pooledObjectType) == false || _poolDictionary[pooledObjectType].Count <= 0)
			{
				ObjectsPoolStaticData.PoolStruct poolStruct = InitPoolStruct(pooledObjectType);

				if (poolStruct.CanPoolIncrease)
					await CreatePool(pooledObjectType);
			}

			GameObject objectToUse = _poolDictionary[pooledObjectType].Dequeue();
			objectToUse.transform.position = position;
			objectToUse.transform.rotation = rotation;
			objectToUse.SetActive(true);
			return objectToUse;
		}

		public async UniTask<GameObject> UseObject(PooledObjectType pooledObjectType, Transform parentTransform)
		{
			if (_poolDictionary.ContainsKey(pooledObjectType) == false || _poolDictionary[pooledObjectType].Count <= 0)
			{
				ObjectsPoolStaticData.PoolStruct poolStruct = InitPoolStruct(pooledObjectType);

				if (poolStruct.CanPoolIncrease)
					await CreatePool(pooledObjectType);
			}

			GameObject objectToUse = _poolDictionary[pooledObjectType].Dequeue();
			objectToUse.SetActive(true);
			objectToUse.transform.SetParent(parentTransform);
			return objectToUse;
		}

		private ObjectsPoolStaticData.PoolStruct InitPoolStruct(PooledObjectType pooledObjectType)
		{
			foreach (ObjectsPoolStaticData.PoolStruct poolStruct in _staticDataService.ObjectsPoolStaticData.PoolsList)
				if (pooledObjectType == poolStruct.pooledObjectType)
					return poolStruct;

			return null;
		}

		public void ReturnObject(PooledObjectType pooledObjectType, GameObject objectToReturn)
		{
			if (_poolDictionary.ContainsKey(pooledObjectType) == false)
				return;

			objectToReturn.SetActive(false);
			_poolDictionary[pooledObjectType].Enqueue(objectToReturn);
		}

		private void CreateNewObject(PooledObjectType pooledObjectType, GameObject prefab)
		{
			Transform parentTransform = _parents[pooledObjectType];

			GameObject newObject = _objectCreator.Instantiate(prefab, parentTransform);

			newObject.SetActive(false);

			_poolDictionary[pooledObjectType].Enqueue(newObject);
		}
	}
}