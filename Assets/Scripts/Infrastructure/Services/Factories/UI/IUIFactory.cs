using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.Factories.UI
{
	public interface IUIFactory
	{
		UniTask CreateUIRoot();
		UniTask CreateMainMenuWindow();
		void DestroyUIRoot();
		void DestroyMainMenuWindow();
	}
}