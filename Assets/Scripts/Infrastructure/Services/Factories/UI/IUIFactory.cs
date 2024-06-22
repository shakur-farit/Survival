using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.Factories.UI
{
	public interface IUIFactory
	{
		UniTask CreateUIRoot();
		UniTask CreateMainMenuWindow();
		UniTask CreateLevelCompleteWindow();
		UniTask CreateGameOverWindow();
		UniTask CreateShopWindow();

		void DestroyUIRoot();
		void DestroyMainMenuWindow();
		void DestroyLevelCompleteWindow();
		void DestroyGameOVerWindow();
		void DestroyShopWindow();
	}
}