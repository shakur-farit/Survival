using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Infrastructure.Services.Factories.Ammo
{
	public class DropFactory : Factory, IDropFactory
	{
		protected DropFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create(Vector2 position)
		{
			AssetsReference reference = await InitReference();

			await CreateObject(reference.DropAddress, position);
		}

		public void Destroy(GameObject gameObject) => 
			Object.Destroy(gameObject);
	}
}