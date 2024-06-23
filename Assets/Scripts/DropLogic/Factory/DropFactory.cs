using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace DropLogic.Factory
{
	public class DropFactory : Infrastructure.FactoryBase.Factory, IDropFactory
	{
		public List<GameObject> DropsList { get; private set; } = new();

		protected DropFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create(Vector2 position)
		{
			AssetsReference reference = await InitReference();

			GameObject drop = await CreateObject(reference.DropAddress, position);

			DropsList.Add(drop);
		}

		public void Destroy(GameObject gameObject) => 
			Object.Destroy(gameObject);
	}
}