using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Soundtrack
{
	public class MusicSourceFactory : IMusicSourceFactory
	{
		private GameObject _musicSource;

		private readonly IAssetsProvider _assetsProvider;
		private readonly IObjectCreatorService _objectsCreator;

		public MusicSourceFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			_assetsProvider = assetsProvider;
			_objectsCreator = objectsCreator;
		}

		public async UniTask Create()
		{
			UIAssetsReference reference = await InitReference();
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.MusicSource);

			_musicSource = _objectsCreator.Instantiate(prefab);
		}

		public void Destroy()
		{
			Object.Destroy(_musicSource);
		}

		private async UniTask<UIAssetsReference> InitReference() =>
			await _assetsProvider.Load<UIAssetsReference>(AssetsReferenceAddress.UIAssetsReference);
	}
}