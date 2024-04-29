using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace UI.Services.Factory
{
	public class UIFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly ObjectCreatorService _objectsCreator;

		public UIFactory(AssetsProvider assetsProvider, ObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public GameObject UIRoot { get; private set; }
		public GameObject MainMenuWindow { get; private set; }


		public async UniTask CreateUIRoot()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.UIRootAddress);
			UIRoot = _objectsCreator.Instantiate(prefab);
		}

		public async UniTask CreateMainMenuWindow()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.MainMenuWindowAddress);
			MainMenuWindow = _objectsCreator.Instantiate(prefab, UIRoot.transform);
		}

		public void DestroyMainMenuWindow() => 
			Object.Destroy(MainMenuWindow);
	}
}
