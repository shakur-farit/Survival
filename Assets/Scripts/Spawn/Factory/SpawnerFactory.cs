using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Spawn.Factory
{
	public class SpawnerFactory : ISpawnerFactory
	{
		public GameObject Spawner { get; private set; }

		private readonly IAssetsProvider _assetsProvider;
		private readonly IObjectCreatorService _objectsCreator;

		public SpawnerFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public async UniTask CreateSpawner()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.SpawnerAddress);
			Spawner = _objectsCreator.Instantiate(prefab);
		}
	}
}