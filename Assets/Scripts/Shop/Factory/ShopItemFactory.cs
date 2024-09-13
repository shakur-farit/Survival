using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace UI.Factory
{
	public class ShopItemFactory : IShopItemFactory
	{
		private readonly List<GameObject> _shopItemList = new();

		private readonly IPoolFactory _poolFactory;

		public List<GameObject> ShopItemList => _shopItemList;

		public ShopItemFactory(IPoolFactory poolFactory) => 
			_poolFactory = poolFactory;

		public void Create(Transform parentTransform, Vector2 position)
		{
			GameObject shopItem = _poolFactory.UseObject(PooledObjectType.ShopItem, parentTransform);

			shopItem.transform.localPosition = position;

			_shopItemList.Add(shopItem);
		}

		public void Destroy(GameObject gameObject) => 
			_poolFactory.ReturnObject(PooledObjectType.ShopItem, gameObject);
	}
}