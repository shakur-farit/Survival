using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;

namespace Ammo.Factory
{
	public class AmmoFactory
	{
		public GameObject Ammo { get; private set; }

		private readonly AssetsProvider _assetsProvider;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly ObjectCreatorService _objectsCreator;

		public AmmoFactory(AssetsProvider assetsProvider, PersistentProgressService persistentProgressService, ObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_persistentProgressService = persistentProgressService;
			_objectsCreator = objectsCreator;
		}

		public async UniTask CreateAmmo(Transform parent)
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			Ammo = _objectsCreator.Instantiate(reference.AmmoPrefab, parent);
		}
	}
}