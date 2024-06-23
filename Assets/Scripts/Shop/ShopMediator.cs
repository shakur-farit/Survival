using StaticData;

namespace Shop
{
	public class ShopMediator : IShopMediator
	{
		private ShopItemView _view;
		private ShopItemBuyer _buyer;

		public void RegisterView(ShopItemView view) => 
			_view = view;

		public void RegisterBuyer(ShopItemBuyer buyer) => 
			_buyer = buyer;

		public void Initialize(WeaponStaticData weaponStaticData)
		{
			_view.SetupView(weaponStaticData);
			_buyer.SetupPrice(weaponStaticData);
		}
	}
}