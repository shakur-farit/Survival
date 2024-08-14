using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Hud.Factory
{
	public class AmmoIconFactory : FactoryBase, IAmmoIconFactory
	{
		private readonly List<GameObject> _ammoIcons = new();

		public List<GameObject> AmmoIcons => _ammoIcons;

		protected AmmoIconFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create(Transform parentTransform, Vector2 position)
		{
			AssetsReference reference = await InitReference();
			GameObject icon = await CreateObject(reference.AmmoIconAddress, parentTransform);
			icon.transform.localPosition = position;
			_ammoIcons.Add(icon);
		}
	}
}