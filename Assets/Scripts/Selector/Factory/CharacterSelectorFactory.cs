using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Selector.Factory
{
	public class CharacterSelectorFactory : ICharacterSelectorFactory
	{
		private GameObject _selector;

		private readonly IAssetsProvider _assetsProvider;
		private readonly IObjectCreatorService _createObject;

		protected CharacterSelectorFactory(IAssetsProvider assetsProvider, IObjectCreatorService createObject)
		{
			_assetsProvider = assetsProvider;
			_createObject = createObject;
		}

		public async UniTask Create()
		{
			UIAssetsReference reference = await _assetsProvider.Load<UIAssetsReference>(AssetsReferenceAddress.UIAssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.CharacterSelectorAddress);

			_selector = _createObject.Instantiate(prefab);
		}

		public void Destroy() => 
			Object.Destroy(_selector);
	}
}