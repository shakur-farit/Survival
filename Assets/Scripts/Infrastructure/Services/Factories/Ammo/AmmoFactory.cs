using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Infrastructure.Services.Factories.Ammo
{
	public class AmmoFactory : Factory, IAmmoFactory
	{
		public AmmoFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create(Transform parentTransform)
		{
			AssetsReference reference = await InitReference();

			GameObject ammo = await CreateObject(reference.AmmoAddress, parentTransform);

			ammo.transform.SetParent(null);
		}

		public void Destroy(GameObject gameObject) => 
			Object.Destroy(gameObject);
	}
}