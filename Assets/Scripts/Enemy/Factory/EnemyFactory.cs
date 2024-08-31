using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Enemy.Factory
{
	public class EnemyFactory : IEnemyFactory
	{
		private readonly IObjectsPool _objectsPool;

		public List<GameObject> EnemiesList { get; set; } = new();

		public EnemyFactory(IObjectsPool objectsPool) =>
			_objectsPool = objectsPool;

		public async UniTask<GameObject> Create(Vector2 position)
		{
			GameObject enemy = await _objectsPool.UseObject(PoolType.Enemy, position);
			EnemiesList.Add(enemy);
			return enemy;
		}

		public void Destroy(GameObject gameObject) => 
			_objectsPool.ReturnObject(PoolType.Enemy, gameObject);
	}
}