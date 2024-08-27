using Cysharp.Threading.Tasks;
using Infrastructure.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UI.Windows;
using UnityEngine;

namespace UI.Factory
{
	public class UIFactory : FactoryBase, IUIFactory
	{
		private GameObject _mainMenuWindow;
		private GameObject _levelCompleteWindow;
		private GameObject _gameOverWindow;
		private GameObject _weaponStatsWindow;
		private GameObject _informationWindow;
		private GameObject _dialogWindow;
		private GameObject _pauseWindow;
		private GameObject _settingsWindow;

		public GameObject UIRoot { get; private set; }

		protected UIFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateUIRoot()
		{
			AssetsReference reference = await InitReference();
			UIRoot = await CreateObject(reference.UIRootAddress);
		}

		public async UniTask CreateMainMenuWindow()
		{
			AssetsReference reference = await InitReference();
			_mainMenuWindow = await CreateObject(reference.MainMenuWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateLevelCompleteWindow()
		{
			AssetsReference reference = await InitReference();
			_levelCompleteWindow = await CreateObject(reference.LevelCompleteWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateGameOverWindow()
		{
			AssetsReference reference = await InitReference();
			_gameOverWindow = await CreateObject(reference.GameOverWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateWeaponStatsWindow()
		{
			AssetsReference reference = await InitReference();
			_weaponStatsWindow = await CreateObject(reference.WeaponStatsWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateInformationWindow()
		{
			AssetsReference reference = await InitReference();
			_informationWindow = await CreateObject(reference.InformationWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateDialogWindow()
		{
			AssetsReference reference = await InitReference();
			_dialogWindow = await CreateObject(reference.DialogWindowAddress, UIRoot.transform);
		}

		public async UniTask CreatePauseWindow()
		{
			AssetsReference reference = await InitReference();
			_pauseWindow = await CreateObject(reference.PauseWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateSettingsWindow()
		{
			AssetsReference reference = await InitReference();
			_settingsWindow = await CreateObject(reference.SettingsWindowAddress, UIRoot.transform);
		}

		public void DestroyUIRoot() => 
			Object.Destroy(UIRoot);

		public void DestroyMainMenuWindow() => 
			Object.Destroy(_mainMenuWindow);

		public void DestroyLevelCompleteWindow() =>
			Object.Destroy(_levelCompleteWindow);

		public void DestroyGameOverWindow() =>
			Object.Destroy(_gameOverWindow);

		public void DestroyWeaponStatsWindow() => 
			Object.Destroy(_weaponStatsWindow);

		public void DestroyInformationWindow() => 
			Object.Destroy(_informationWindow);

		public void DestroyDialogWindow() => 
			Object.Destroy(_dialogWindow);

		public void DestroyPauseWindow() =>
			Object.Destroy(_pauseWindow);

		public void DestroySettingsWindow() =>
			Object.Destroy(_settingsWindow);
	}
}
