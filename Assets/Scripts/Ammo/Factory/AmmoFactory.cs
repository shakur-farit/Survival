using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Ammo.Factory
{
	public class AmmoFactory : IAmmoFactory
	{
		public GameObject Ammo { get; private set; }

		private readonly IAssetsProvider _assetsProvider;
		private readonly IObjectCreatorService _objectsCreator;

		public AmmoFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public async UniTask CreateAmmo(Transform parent)
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.AmmoAddress);

			Ammo = _objectsCreator.Instantiate(prefab, parent);

			Ammo.transform.SetParent(null);
		}
	}
}