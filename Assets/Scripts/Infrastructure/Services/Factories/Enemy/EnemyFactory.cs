using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Infrastructure.Services.Factories.Enemy
{
	public class EnemyFactory : Factory, IEnemyFactory
	{
		public List<GameObject> EnemiesList { get; set; } = new();

		public EnemyFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask<GameObject> Create(Vector2 position)
		{
			AssetsReference reference = await InitReference();
			GameObject enemy = await CreateObject(reference.EnemyAddress, position);
			EnemiesList.Add(enemy);
			return enemy;
		}

		public void Destroy(GameObject gameObject) => 
			Object.Destroy(gameObject);
	}
}