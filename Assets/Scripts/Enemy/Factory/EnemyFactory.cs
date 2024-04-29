using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Enemy.Factory
{
	public class EnemyFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly ObjectCreatorService _objectCreator;

		public GameObject Enemy { get; private set; }

		public EnemyFactory(AssetsProvider assetsProvider, ObjectCreatorService objectCreator)
		{
			_assetsProvider = assetsProvider;
			_objectCreator = objectCreator;
		}

		public async UniTask CreateEnemy(Vector2 position)
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.EnemyAddress);
			Enemy = _objectCreator.Instantiate(prefab, position);
		}
	}
}