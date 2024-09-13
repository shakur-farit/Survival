using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace DropLogic.Factory
{
	public class DropFactory : IDropFactory
	{
		private readonly IPoolFactory _poolFactory;

		public List<GameObject> DropsList { get; } = new();

		protected DropFactory(IPoolFactory poolFactory) => 
			_poolFactory = poolFactory;

		public void Create(Vector2 position)
		{
			GameObject drop = _poolFactory.UseObject(PooledObjectType.Drop, position);

			DropsList.Add(drop);
		}

		public void Destroy(GameObject gameObject) => 
			_poolFactory.ReturnObject(PooledObjectType.Drop, gameObject);
	}
}