using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace HUD.Factory
{
	public class HUDFactory : IHUDFactory
	{
		public GameObject HUD { private set; get; }

		private readonly IAssetsProvider _assetsProvider;
		private readonly IObjectCreatorService _objectsCreator;

		public HUDFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public async UniTask CreateHUD()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.HUDAddress);
			HUD = _objectsCreator.Instantiate(prefab);
		}
	}
}