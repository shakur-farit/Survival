using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Factory
{
	public interface IShopItemFactory
	{
		UniTask Create(Transform parentTransform, Vector2 position);
		void Destroy(GameObject gameObject);
		List<GameObject> ShopItemList { get; }
	}
}