using Cysharp.Threading.Tasks;
using Infrastructure.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace UI.Factory
{
	public class ShopItemFactory : FactoryBase, IShopItemFactory
	{
		protected ShopItemFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create(Transform parentTransform, Vector2 position)
		{
			AssetsReference reference = await InitReference();
			GameObject shopItem = await CreateObject(reference.ShopItemAddress, parentTransform);

			shopItem.transform.localPosition = position;
		}
	}
}