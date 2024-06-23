using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Hud.Factory
{
	public class HudFactory : Infrastructure.FactoryBase.Factory, IHudFactory
	{
		private GameObject _hud;

		public HudFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create()
		{
			AssetsReference reference = await InitReference();
			_hud = await CreateObject(reference.HudAddress);
		}

		public void Destroy() => 
			Object.Destroy(_hud);
	}
}