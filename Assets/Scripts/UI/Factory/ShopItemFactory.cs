using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace UI.Factory
{
	public class ShopItemFactory : IShopItemFactory
	{
		private readonly IObjectsPool _objectsPool;

		public ShopItemFactory(IObjectsPool objectsPool) => 
			_objectsPool = objectsPool;

		public async UniTask Create(Transform parentTransform, Vector2 position)
		{
			GameObject shopItem = await _objectsPool.UseObject(PooledObjectType.ShopItem, parentTransform);

			shopItem.transform.localPosition = position;
		}
	}
}