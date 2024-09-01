using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace DropLogic.Factory
{
	public class DropFactory : IDropFactory
	{
		private readonly IObjectsPool _objectsPool;

		public List<GameObject> DropsList { get; } = new();

		protected DropFactory(IObjectsPool objectsPool) => 
			_objectsPool = objectsPool;

		public async UniTask Create(Vector2 position)
		{
			GameObject drop = await _objectsPool.UseObject(PooledObjectType.Drop, position);

			DropsList.Add(drop);
		}

		public void Destroy(GameObject gameObject) => 
			_objectsPool.ReturnObject(PooledObjectType.Drop, gameObject);
	}
}