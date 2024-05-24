using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Infrastructure.Services.Factories.Ammo
{
	public class AmmoFactory : Factory, IAmmoFactory
	{
		private GameObject _ammo;

		public AmmoFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create(Transform parentTransform)
		{
			AssetsReference reference = await InitReference();

			_ammo = await CreateObject(reference.AmmoAddress, parentTransform);

			_ammo.transform.SetParent(null);
		}

		public void Destroy() => 
			Object.Destroy(_ammo);
	}
}