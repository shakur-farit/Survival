using System.Collections;
using Cysharp.Threading.Tasks;
using Infrastructure.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Hud.Factory
{
	public class HudFactory : FactoryBase, IHudFactory
	{
		public GameObject Hud { get; private set; }

		public HudFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create()
		{
			AssetsReference reference = await InitReference();
			Hud = await CreateObject(reference.HudAddress);
		}

		public void Destroy() => 
			Object.Destroy(Hud);
	}
}