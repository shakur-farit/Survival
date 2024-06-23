using StaticData;

namespace Shop
{
	public interface IShopMediator
	{
		void RegisterView(ShopItemView view);
		void RegisterBuyer(ShopItemBuyer buyer);
		void Initialize(WeaponStaticData weaponStaticData);
	}
}