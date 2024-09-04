using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using Pool;
using UnityEngine;

namespace UI.Factory
{
	public class ShopItemFactory : IShopItemFactory
	{
		private readonly IObjectsPool _objectsPool;
		private readonly IAssetsProvider _assetsProvider;
		private readonly IObjectCreatorService _createObject;

		public ShopItemFactory(IObjectsPool objectsPool, IAssetsProvider assetsProvider, IObjectCreatorService createObject)
		{
			_objectsPool = objectsPool;
			_assetsProvider = assetsProvider;
			_createObject = createObject;
		}

		public async UniTask Create(Transform parentTransform, Vector2 position)
		{
			//GameObject shopItem = await _objectsPool.UseObject(PooledObjectType.ShopItem, parentTransform);

			UIAssetsReference reference = await _assetsProvider.Load<UIAssetsReference>(AssetsReferenceAddress.UIAssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.ShopItemAddress);
			GameObject shopItem = _createObject.Instantiate(prefab, parentTransform);

			shopItem.transform.localPosition = position;
		}
	}
}