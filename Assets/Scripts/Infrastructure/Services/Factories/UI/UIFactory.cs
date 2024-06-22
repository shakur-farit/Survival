using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Infrastructure.Services.Factories.UI
{
	public class UIFactory : Factory, IUIFactory
	{
		private GameObject _uiRoot;
		private GameObject _mainMenuWindow;
		private GameObject _levelCompleteWindow;
		private GameObject _gameOverWindow;
		private GameObject _shopWindow;

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

		public async UniTask CreateLevelCompleteWindow()
		{
			AssetsReference reference = await InitReference();
			_levelCompleteWindow = await CreateObject(reference.LevelCompleteWindowAddress, _uiRoot.transform);
		}

		public async UniTask CreateGameOverWindow()
		{
			AssetsReference reference = await InitReference();
			_gameOverWindow = await CreateObject(reference.GameOverWindowAddress, _uiRoot.transform);
		}

		public async UniTask CreateShopWindow()
		{
			AssetsReference reference = await InitReference();
			_shopWindow = await CreateObject(reference.ShopWindowAddress, _uiRoot.transform);
		}

		public void DestroyUIRoot() => 
			Object.Destroy(_uiRoot);

		public void DestroyMainMenuWindow() => 
			Object.Destroy(_mainMenuWindow);

		public void DestroyLevelCompleteWindow() =>
			Object.Destroy(_levelCompleteWindow);

		public void DestroyGameOVerWindow() =>
			Object.Destroy(_gameOverWindow);

		public void DestroyShopWindow() => 
			Object.Destroy(_shopWindow);
	}
}
