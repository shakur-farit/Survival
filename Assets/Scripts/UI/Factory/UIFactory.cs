using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace UI.Factory
{
	public class UIFactory : IUIFactory
	{
		private GameObject _mainMenuWindow;
		private GameObject _levelCompleteWindow;
		private GameObject _gameOverWindow;
		private GameObject _weaponStatsWindow;
		private GameObject _informationWindow;
		private GameObject _dialogWindow;
		private GameObject _pauseWindow;
		private GameObject _settingsWindow;

		private readonly IObjectCreatorService _objectsCreator;
		private readonly IAssetsProvider _assetsProvider;

		public UIFactory(IObjectCreatorService objectsCreator, IAssetsProvider assetsProvider)
		{
			_objectsCreator = objectsCreator;
			_assetsProvider = assetsProvider;
		}

		public GameObject UIRoot { get; private set; }

		public async UniTask CreateUIRoot()
		{
			UIAssetsReference reference = await InitReference(); 
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.UIRootAddress);

			UIRoot = _objectsCreator.Instantiate(prefab);
		}

		public async UniTask CreateMainMenuWindow()
		{
			UIAssetsReference reference = await InitReference();
			_mainMenuWindow = await CreateObject(reference.MainMenuWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateLevelCompleteWindow()
		{
			UIAssetsReference reference = await InitReference();
			_levelCompleteWindow = await CreateObject(reference.LevelCompleteWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateGameOverWindow()
		{
			UIAssetsReference reference = await InitReference();
			_gameOverWindow = await CreateObject(reference.GameOverWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateWeaponStatsWindow()
		{
			UIAssetsReference reference = await InitReference();
			_weaponStatsWindow = await CreateObject(reference.WeaponStatsWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateInformationWindow()
		{
			UIAssetsReference reference = await InitReference();
			_informationWindow = await CreateObject(reference.InformationWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateDialogWindow()
		{
			UIAssetsReference reference = await InitReference();
			_dialogWindow = await CreateObject(reference.DialogWindowAddress, UIRoot.transform);
		}

		public async UniTask CreatePauseWindow()
		{
			UIAssetsReference reference = await InitReference();
			_pauseWindow = await CreateObject(reference.PauseWindowAddress, UIRoot.transform);
		}

		public async UniTask CreateSettingsWindow()
		{
			UIAssetsReference reference = await InitReference();
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

		protected async UniTask<GameObject> CreateObject(string objectAddress, Transform parentTransform)
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(objectAddress);

			return _objectsCreator.Instantiate(prefab, parentTransform);
		}

		protected async UniTask<UIAssetsReference> InitReference() =>
			await _assetsProvider.Load<UIAssetsReference>(AssetsReferenceAddress.UIAssetsReference);
	}
}
