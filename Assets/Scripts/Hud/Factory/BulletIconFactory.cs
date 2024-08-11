using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Hud.Factory
{
	public class BulletIconFactory : FactoryBase, IBulletIconFactory
	{
		private readonly Stack<GameObject> _bulletIcons = new();

		public Stack<GameObject> BulletIcons => _bulletIcons;

		protected BulletIconFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create(Transform parentTransform, Vector2 position)
		{
			AssetsReference reference = await InitReference();
			GameObject icon = await CreateObject(reference.BulletIconAddress, parentTransform);
			icon.transform.localPosition = position;
			_bulletIcons.Push(icon);
		}

		public void Destroy()
		{
			GameObject bulletIcon = _bulletIcons.Pop();
			Object.Destroy(bulletIcon);
		}
	}
}