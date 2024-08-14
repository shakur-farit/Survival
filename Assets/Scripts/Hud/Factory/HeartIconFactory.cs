using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Hud.Factory
{
	public class HeartIconFactory : FactoryBase, IHeartIconFactory
	{
		private readonly List<GameObject> _heartIcons = new();

		public List<GameObject> HeartIcons => _heartIcons;

		protected HeartIconFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create(Transform parentTransform, Vector2 position)
		{
			AssetsReference reference = await InitReference();
			GameObject icon = await CreateObject(reference.HeartIconAddress, parentTransform);
			icon.transform.localPosition = position;
			_heartIcons.Add(icon);
		}
	}
}