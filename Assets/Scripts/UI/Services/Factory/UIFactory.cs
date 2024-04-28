using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
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
			UIRoot = _objectsCreator.Instantiate(reference.UIRootPrefab);
		}

		public async UniTask CreateMainMenuWindow()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			MainMenuWindow = _objectsCreator.Instantiate(reference.MainMenuWindowPrefab, UIRoot.transform);
		}

		public void DestroyMainMenuWindow() => 
			Object.Destroy(MainMenuWindow);
	}
}
