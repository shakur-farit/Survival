using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Services.Factory
{
	public interface IUIFactory
	{
		GameObject UIRoot { get; }
		GameObject MainMenuWindow { get; }
		UniTask CreateUIRoot();
		UniTask CreateMainMenuWindow();
		void DestroyMainMenuWindow();
	}
}