using UnityEngine;
using Zenject;

namespace Infrastructure.Services.ObjectCreator
{
	public class ObjectCreatorService
	{
		private readonly IInstantiator _instantiator;

		public ObjectCreatorService(IInstantiator instantiator)=>
			_instantiator = instantiator;

		public GameObject Instantiate(GameObject prefab) =>
			_instantiator.InstantiatePrefab(prefab);

		public GameObject Instantiate(GameObject prefab, Transform parent) =>
			_instantiator.InstantiatePrefab(prefab, parent);

		public GameObject Instantiate(GameObject prefab, Vector2 position) =>
			_instantiator.InstantiatePrefab(prefab, position, Quaternion.identity, null);
	}
}