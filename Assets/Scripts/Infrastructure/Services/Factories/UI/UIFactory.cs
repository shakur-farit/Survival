using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Infrastructure.Services.Factories.UI
{
	public class UIFactory : Infrastructure.Services.Factories.Factory, IUIFactory
	{
		private GameObject _uiRoot;
		private GameObject _mainMenuWindow;

		protected UIFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateUIRoot()
		{
			AssetsReference reference = await InitReference();
			_uiRoot = await CreateObject(reference.UIRootAddress);
		}

		public async UniTask CreateMainMenuWindow()
		{
			AssetsReference reference = await InitReference();
			_mainMenuWindow = await CreateObject(reference.MainMenuWindowAddress, _uiRoot.transform);
		}

		public void DestroyUIRoot() => 
			Object.Destroy(_uiRoot);

		public void DestroyMainMenuWindow() => 
			Object.Destroy(_mainMenuWindow);
	}
}
