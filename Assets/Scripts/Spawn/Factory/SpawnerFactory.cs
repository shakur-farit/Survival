using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Spawn.Factory
{
	public class SpawnerFactory
	{
		public GameObject Spawner { get; private set; }

		private readonly AssetsProvider _assetsProvider;
		private readonly ObjectCreatorService _objectsCreator;

		public SpawnerFactory(AssetsProvider assetsProvider, ObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public async UniTask CreateSpawner()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.MainMenuWindowAddress);
			Spawner = _objectsCreator.Instantiate(prefab);
		}
	}
}