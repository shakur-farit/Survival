using Cysharp.Threading.Tasks;
using Infrastructure.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SpecialEffects.Factory
{
	public class SpecialEffectsFactory : FactoryBase, ISpecialEffectsFactory
	{
		protected SpecialEffectsFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask<GameObject> CreateShootEffect(Vector2 position)
		{
			AssetsReference reference = await InitReference();

			return await CreateObject(reference.ShootSpecialEffetcAddress, position);
		}

		public void Destroy(GameObject gameObject) => 
			Object.Destroy(gameObject);
	}
}