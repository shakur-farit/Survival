using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Character.Factory
{
	public class CharacterFactory : Infrastructure.FactoryBase.Factory, ICharacterFactory
	{
		public GameObject Character { get; private set; }

		public CharacterFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create()
		{
			AssetsReference reference = await InitReference();
			Character = await CreateObject(reference.CharacterAddress);
		}

		public void Destroy() => 
			Object.Destroy(Character);
	}
}