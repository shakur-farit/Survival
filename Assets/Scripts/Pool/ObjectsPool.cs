using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Pool
{
	public class ObjectsPool : IObjectsPool
	{
		private Transform objectPoolTransform;
		private Dictionary<string, Queue<GameObject>> poolDictionary = new();

		private readonly IObjectCreatorService _objectCreator;
		private readonly IAssetsProvider _assetsProvider;

		public ObjectsPool(IObjectCreatorService objectCreator, IAssetsProvider assetsProvider)
		{
			_objectCreator = objectCreator;
			_assetsProvider = assetsProvider;
		}

		public async UniTask CreatePool(string address, int poolSize)
		{
			if (objectPoolTransform == null)
				objectPoolTransform = new GameObject("Objects Pool").transform;

			GameObject prefab = await _assetsProvider.Load<GameObject>(address);

			string prefabName = prefab.name;

			Transform parentTransform = new GameObject(prefabName + "Anchor").transform;

			parentTransform.transform.SetParent(objectPoolTransform);

			if (poolDictionary.ContainsKey(address) == false)
			{
				poolDictionary.Add(address, new Queue<GameObject>());

				for (int i = 0; i < poolSize; i++)
				{
					GameObject newObject = _objectCreator.Instantiate(prefab, parentTransform);

					newObject.SetActive(false);

					poolDictionary[address].Enqueue(newObject);
				}
			}
		}

		public GameObject UseObject(string address, Vector2 position = default)
		{
			Debug.Log(poolDictionary[address].Count);

			if (poolDictionary.ContainsKey(address) == false || poolDictionary[address].Count <= 0)
			{
				Debug.Log($"There is no pool for {address}");
				return null;
			}

			GameObject objectToUse = poolDictionary[address].Dequeue();
			objectToUse.SetActive(true);
			objectToUse.transform.position = position;
			return objectToUse;
		}

		public void ReturnObject(string address, GameObject objectToReturn)
		{
			if (poolDictionary.ContainsKey(address) == false)
				return;

			objectToReturn.SetActive(false);
			poolDictionary[address].Enqueue(objectToReturn);

			Debug.Log(poolDictionary[address].Count);

		}
	}
}