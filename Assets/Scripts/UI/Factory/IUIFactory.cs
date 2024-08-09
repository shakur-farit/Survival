using Cysharp.Threading.Tasks;

namespace UI.Factory
{
	public interface IUIFactory
	{
		UniTask CreateUIRoot();
		UniTask CreateMainMenuWindow();
		UniTask CreateLevelCompleteWindow();
		UniTask CreateGameOverWindow();
		UniTask CreateWeaponStatsWindow();
		UniTask CreateInformationWindow();

		void DestroyUIRoot();
		void DestroyMainMenuWindow();
		void DestroyLevelCompleteWindow();
		void DestroyGameOverWindow();
		void DestroyWeaponStatsWindow();
		void DestroyInformationWindow();
	}
}