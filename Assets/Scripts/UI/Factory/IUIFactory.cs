using Cysharp.Threading.Tasks;

namespace UI.Factory
{
	public interface IUIFactory
	{
		UniTask CreateUIRoot();
		UniTask CreateMainMenuWindow();
		UniTask CreateLevelCompleteWindow();
		UniTask CreateGameOverWindow();

		void DestroyUIRoot();
		void DestroyMainMenuWindow();
		void DestroyLevelCompleteWindow();
		void DestroyGameOVerWindow();
	}
}