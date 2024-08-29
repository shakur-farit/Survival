using System;
using System.Collections.Generic;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace UI.Windows
{
	public class ObjectsPool : IObjectsPool
	{
		private Transform objectPoolTransform;
		private Dictionary<int, Queue<GameObject>> poolDictionary = new();

		private readonly IObjectCreatorService _objectCreator;

		public ObjectsPool(IObjectCreatorService objectCreator)
		{
			_objectCreator = objectCreator;
		}

		public void CreatePool(GameObject prefab, int poolSize)
		{
			if (objectPoolTransform == null)
				objectPoolTransform = new GameObject("Objects Pool").transform;

			int poolKey = prefab.GetInstanceID();

			string prefabName = prefab.name;

			Transform parentTransform = new GameObject(prefabName + "Anchor").transform;

			parentTransform.transform.SetParent(objectPoolTransform);

			if (poolDictionary.ContainsKey(poolKey) == false)
			{
				poolDictionary.Add(poolKey, new Queue<GameObject>());

				for (int i = 0; i < poolSize; i++)
				{
					GameObject newObject = _objectCreator.Instantiate(prefab, parentTransform);

					newObject.SetActive(false);

					poolDictionary[poolKey].Enqueue(newObject);
				}
			}
		}

		public GameObject ReuseComponent(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			int poolKey = prefab.GetInstanceID();

			if (!poolDictionary.ContainsKey(poolKey))
			{
				Debug.Log("No object pool for " + prefab);
				return null;
			}

			GameObject componentToReuse = GetComponentFromPool(poolKey);

			ResetObject(position, rotation, componentToReuse, prefab);

			return componentToReuse;
		}

		public GameObject GetComponentFromPool(int poolKey)
		{
			GameObject componentToReuse = poolDictionary[poolKey].Dequeue();
			poolDictionary[poolKey].Enqueue(componentToReuse);

			if (componentToReuse.gameObject.activeSelf == true)
			{
				componentToReuse.gameObject.SetActive(false);
			}

			return componentToReuse;
		}

		public void ResetObject(Vector3 position, Quaternion rotation, GameObject componentToReuse, GameObject prefab)
		{
			componentToReuse.transform.position = position;
			componentToReuse.transform.rotation = rotation;
			componentToReuse.gameObject.transform.localScale = prefab.transform.localScale;
		}
	}
}