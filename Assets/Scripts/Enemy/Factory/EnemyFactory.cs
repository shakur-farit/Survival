using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Enemy.Factory
{
	public class EnemyFactory : IEnemyFactory
	{
		private readonly IObjectsPoolFactory _objectsPoolFactory;

		public List<GameObject> EnemiesList { get; set; } = new();

		public EnemyFactory(IObjectsPoolFactory objectsPoolFactory) =>
			_objectsPoolFactory = objectsPoolFactory;

		public async UniTask<GameObject> Create(Vector2 position)
		{
			GameObject enemy = await _objectsPoolFactory.UseObject(PooledObjectType.Enemy, position);
			EnemiesList.Add(enemy);
			return enemy;
		}

		public void Destroy(GameObject gameObject) => 
			_objectsPoolFactory.ReturnObject(PooledObjectType.Enemy, gameObject);
	}
}