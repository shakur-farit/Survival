using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace UI.Factory
{
	public class ShopItemFactory : IShopItemFactory
	{
		private readonly List<GameObject> _shopItemList = new();

		private readonly IObjectsPool _objectsPool;

		public List<GameObject> ShopItemList => _shopItemList;

		public ShopItemFactory(IObjectsPool objectsPool) => 
			_objectsPool = objectsPool;

		public async UniTask Create(Transform parentTransform, Vector2 position)
		{
			GameObject shopItem = await _objectsPool.UseObject(PooledObjectType.ShopItem, parentTransform);

			shopItem.transform.localPosition = position;

			_shopItemList.Add(shopItem);
		}

		public void Destroy(GameObject gameObject) => 
			_objectsPool.ReturnObject(PooledObjectType.ShopItem, gameObject);
	}
}