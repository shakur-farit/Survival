using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Character.Factory
{
	public class CharacterFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly ObjectCreatorService _objectCreator;

		public GameObject Character { get; private set; }

		public CharacterFactory(AssetsProvider assetsProvider, ObjectCreatorService objectCreator)
		{
			_assetsProvider = assetsProvider;
			_objectCreator = objectCreator;
		}

		public async UniTask CreateCharacter()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.CharacterAddress);
			Character = _objectCreator.Instantiate(prefab);
		}
	}
}