using Cysharp.Threading.Tasks;
using Infrastructure.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Selector.Factory
{
	public class CharacterSelectorFactory : FactoryBase, ICharacterSelectorFactory
	{
		private GameObject _selector;

		protected CharacterSelectorFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create()
		{
			AssetsReference reference = await InitReference();
			_selector = await CreateObject(reference.CharacterSelectorAddress);
		}

		public void Destroy() => 
			Object.Destroy(_selector);
	}
}