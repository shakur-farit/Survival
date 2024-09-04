using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Hud.Factory
{
	public class HudFactory : IHudFactory
	{
		private readonly IAssetsProvider _assetsProvider;
		private readonly IObjectCreatorService _createObject;

		public GameObject Hud { get; private set; }

		public HudFactory(IAssetsProvider assetsProvider, IObjectCreatorService createObject)
		{
			_assetsProvider = assetsProvider;
			_createObject = createObject;
		}


		public async UniTask Create()
		{
			UIAssetsReference reference = await _assetsProvider.Load<UIAssetsReference>(AssetsReferenceAddress.UIAssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.HudAddress);

			Hud = _createObject.Instantiate(prefab);
		}

		public void Destroy() => 
			Object.Destroy(Hud);
	}
}