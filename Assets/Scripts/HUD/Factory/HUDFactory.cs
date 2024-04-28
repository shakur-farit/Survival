using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using UnityEngine;

namespace Character.Factory
{
	public class HUDFactory
	{
		public GameObject HUD { private set; get; }

		private readonly AssetsProvider _assetsProvider;
		private readonly ObjectCreatorService _objectsCreator;

		public HUDFactory(AssetsProvider assetsProvider, ObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public async UniTask CreateHUD()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			HUD = _objectsCreator.Instantiate(reference.HUDPrefab);
		}
	}
}