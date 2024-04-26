using Assets.Scripts.Infrastructure.Services.AssetsManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.Services.Factory
{
	public class UIFactory
	{
		private readonly AssetsProvider _assetsProvider;

		public UIFactory(AssetsProvider assetsProvider) => 
			_assetsProvider = assetsProvider;

		public GameObject UIRoot { get; private set; }
		public GameObject MainMenuWindow { get; private set; }


		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<GameObject>(AssetsAddresses.UIRoot);
			await _assetsProvider.Load<GameObject>(AssetsAddresses.MainMenuWindow);
		}


		public async UniTask CreateUIRoot()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.UIRoot);
			UIRoot = _assetsProvider.Instantiate(prefab);
		}

		public async UniTask CreateMainMenuWindow()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.MainMenuWindow);
			MainMenuWindow = _assetsProvider.Instantiate(prefab, UIRoot.transform);
		}

		public void DestroyMainMenuWindow() => 
			Object.Destroy(MainMenuWindow);
	}
}
