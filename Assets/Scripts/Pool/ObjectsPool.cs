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

		private readonly Dictionary<PoolType, Queue<GameObject>> _poolDictionary = new();
		private readonly Dictionary<PoolType, Transform> _parents = new();

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

		public async UniTask CreatePool(PoolType poolType)
		{
			if (_objectPoolTransform == null) 
				_objectPoolTransform = new GameObject("Pool Group").transform;

			ObjectsPoolStaticData.PoolStruct poolStruct = InitPoolStruct(poolType);

			GameObject prefab = await _assetsProvider.Load<GameObject>(poolStruct.PooledPrefabAddress);

			string prefabName = prefab.name;

			if (_poolDictionary.ContainsKey(poolType) == false)
			{
				_parentTransform = new GameObject(prefabName + "Anchor").transform;

				_parents.Add(poolType, _parentTransform);
				_poolDictionary.Add(poolType, new Queue<GameObject>());

				_parentTransform.transform.SetParent(_objectPoolTransform);
			}

			if (poolType == poolStruct.PoolType)
				for (int i = 0; i < poolStruct.PoolSize; i++)
					CreateNewObject(poolType, prefab);
		}

		public async UniTask<GameObject> UseObject(PoolType poolType, Vector2 position = default, Quaternion rotation = default)
		{
			if (_poolDictionary.ContainsKey(poolType) == false || _poolDictionary[poolType].Count <= 0)
			{
				ObjectsPoolStaticData.PoolStruct poolStruct = InitPoolStruct(poolType);

				if (poolStruct.CanPoolIncrease) 
					await CreatePool(poolType);
			}

			GameObject objectToUse = _poolDictionary[poolType].Dequeue();
			objectToUse.SetActive(true);
			objectToUse.transform.position = position;
			objectToUse.transform.rotation = rotation;
			return objectToUse;
		}

		private ObjectsPoolStaticData.PoolStruct InitPoolStruct(PoolType poolType)
		{
			foreach (ObjectsPoolStaticData.PoolStruct poolStruct in _staticDataService.ObjectsPoolStaticData.PoolsList)
				if (poolType == poolStruct.PoolType)
					return poolStruct;

			return null;
		}

		public void ReturnObject(PoolType poolType, GameObject objectToReturn)
		{
			if (_poolDictionary.ContainsKey(poolType) == false)
				return;

			objectToReturn.SetActive(false);
			_poolDictionary[poolType].Enqueue(objectToReturn);
		}

		private void CreateNewObject(PoolType poolType, GameObject prefab)
		{
			Transform parentTransform = _parents[poolType];

			GameObject newObject = _objectCreator.Instantiate(prefab, parentTransform);

			newObject.SetActive(false);

			_poolDictionary[poolType].Enqueue(newObject);
		}
	}
}