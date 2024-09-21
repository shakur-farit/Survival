using System.Collections.Generic;
using UnityEngine;

namespace Shop.Factory
{
	public interface IShopItemFactory
	{
		void Create(Transform parentTransform, Vector2 position);
		void Destroy(GameObject gameObject);
		List<GameObject> ShopItemList { get; }
	}
}