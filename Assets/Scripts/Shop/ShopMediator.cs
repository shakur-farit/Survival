using StaticData;
using UnityEngine;

namespace Shop
{
	public class ShopMediator : IShopMediator
	{
		private ShopItemView _view;
		private ShopItemBuyer _buyer;

		public void RegisterView(ShopItemView view)
		{
			Debug.Log("Reg");
			_view = view;
		}

		public void RegisterBuyer(ShopItemBuyer buyer) => 
			_buyer = buyer;

		public void Initialize(WeaponStaticData weaponStaticData)
		{
			Debug.Log(_buyer);
			_view.SetupView(weaponStaticData);
			_buyer.SetupPrice(weaponStaticData);
		}
	}
}