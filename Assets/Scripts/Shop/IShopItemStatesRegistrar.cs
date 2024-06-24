namespace Shop
{
	public interface IShopItemStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IShopItemState;
	}
}