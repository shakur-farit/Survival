using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Infrastructure.FactoryBase
{
	public class SpecialEffectsFactory : Factory, ISpecialEffectsFactory
	{
		protected SpecialEffectsFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create(Vector2 position)
		{
			AssetsReference reference = await InitReference();

			await CreateObject(reference.ShootSpecialEffetcAddress, position);
		}

		public void Destroy(GameObject gameObject) => 
			Object.Destroy(gameObject);
	}
}