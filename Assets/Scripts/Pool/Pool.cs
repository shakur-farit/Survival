using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
	public class Pool
	{
		private readonly Queue<GameObject> _objectsPool = new();
		private Transform _parentTransform;

		public GameObject UseObject()
		{
			if (_objectsPool.Count == 0)
				return null;

			GameObject objectToUse = _objectsPool.Dequeue();

			objectToUse.SetActive(true);
			return objectToUse;
		}

		public void ReturnObject(GameObject objectToReturn)
		{
			objectToReturn.SetActive(false);

			if(objectToReturn.transform.parent != _parentTransform)
				objectToReturn.transform.SetParent(_parentTransform);

			_objectsPool.Enqueue(objectToReturn);
		}

		public void AddObject(GameObject objectToAdd, Transform poolsGroupTransform)
		{
			objectToAdd.SetActive(false);

			if (_parentTransform == null)
			{
				string parentName = objectToAdd.name.Contains("(Clone)") 
					? objectToAdd.name.Replace("(Clone)", "") 
					: objectToAdd.name;

				_parentTransform = new GameObject(parentName + "Anchor").transform;
				_parentTransform.SetParent(poolsGroupTransform);
			}

			objectToAdd.transform.SetParent(_parentTransform);
			_objectsPool.Enqueue(objectToAdd);
		}
	}
}