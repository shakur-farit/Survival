using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Infrastructure.Services.Factories.Spawner
{
	public class SpawnerFactory : Factory, ISpawnerFactory
	{
		private GameObject _spawner;

		protected SpawnerFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create()
		{
			AssetsReference reference = await InitReference();
			_spawner = await CreateObject(reference.SpawnerAddress);
		}

		public void Destroy() => 
			Object.Destroy(_spawner);
	}
}