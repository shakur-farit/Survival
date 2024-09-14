using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace Enemy.Factory
{
	public class EnemyFactory : IEnemyFactory
	{
		private readonly IPoolFactory _poolFactory;

		public List<GameObject> EnemiesList { get; set; } = new();

		public EnemyFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public GameObject Create(Vector2 position)
		{
			GameObject enemy = _poolFactory.UseObject(PooledObjectType.Enemy, position);
			EnemiesList.Add(enemy);
			return enemy;
		}

		public void Destroy(GameObject gameObject) => 
			_poolFactory.ReturnObject(PooledObjectType.Enemy, gameObject);
	}
}