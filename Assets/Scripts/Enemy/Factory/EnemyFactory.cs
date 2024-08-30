using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using Pool;
using UI.Windows;
using UnityEngine;
using UnityEngine.UIElements;

namespace Enemy.Factory
{
	public class EnemyFactory : FactoryBase, IEnemyFactory
	{
		private readonly IObjectsPool _objectsPool;

		public List<GameObject> EnemiesList { get; set; } = new();

		public EnemyFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator, IObjectsPool objectsPool) : 
			base(assetsProvider, objectsCreator) =>
			_objectsPool = objectsPool;

		public async UniTask<GameObject> Create(Vector2 position)
		{
			AssetsReference reference = await InitReference();
			GameObject enemy = _objectsPool.UseObject(reference.EnemyAddress, position);
			EnemiesList.Add(enemy);
			return enemy;
		}

		public async void Destroy(GameObject gameObject)
		{
			AssetsReference reference = await InitReference();
			_objectsPool.ReturnObject(reference.EnemyAddress, gameObject);
		}
	}
}