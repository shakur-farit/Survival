using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Infrastructure.Factory
{
	public class FactoryBase
	{
		protected readonly IAssetsProvider AssetsProvider;
		protected readonly IObjectCreatorService ObjectsCreator;

		protected FactoryBase(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			AssetsProvider = assetsProvider;
			ObjectsCreator = objectsCreator;
		}

		protected async UniTask<GameObject> CreateObject(string objectAddress)
		{
			GameObject prefab = await AssetsProvider.Load<GameObject>(objectAddress);

			return ObjectsCreator.Instantiate(prefab);
		}

		protected async UniTask<GameObject> CreateObject(string objectAddress, Vector2 position)
		{
			GameObject prefab = await AssetsProvider.Load<GameObject>(objectAddress);

			return ObjectsCreator.Instantiate(prefab, position);
		}

		protected async UniTask<GameObject> CreateObject(string objectAddress, Transform parentTransform)
		{
			GameObject prefab = await AssetsProvider.Load<GameObject>(objectAddress);

			return ObjectsCreator.Instantiate(prefab, parentTransform);
		}

		protected async UniTask<GameObject> CreateObject(string objectAddress, Transform parentTransform, Vector2 position)
		{
			GameObject prefab = await AssetsProvider.Load<GameObject>(objectAddress);

			return ObjectsCreator.Instantiate(prefab, parentTransform, position);
		}

		protected async UniTask<AssetsReference> InitReference() => 
			await AssetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
	}
}