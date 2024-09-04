using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using Pool;
using UnityEngine;

namespace Hud.Factory
{
	public class HeartIconFactory : IHeartIconFactory
	{
		private readonly List<GameObject> _heartIcons = new();
		private readonly IObjectsPool _objectsPool;
		private readonly IAssetsProvider _assetsProvider;
		private readonly IObjectCreatorService _createObject;

		public List<GameObject> HeartIcons => _heartIcons;

		protected HeartIconFactory(IObjectsPool objectsPool, IAssetsProvider assetsProvider, IObjectCreatorService createObject)
		{
			_objectsPool = objectsPool;
			_assetsProvider = assetsProvider;
			_createObject = createObject;
		}

		public async UniTask Create(Transform parentTransform, Vector2 position)
		{

			//GameObject icon = await _objectsPool.UseObject(PooledObjectType.HeartIcon, parentTransform);
			//icon.transform.localPosition = position;

			UIAssetsReference reference = await _assetsProvider.Load<UIAssetsReference>(AssetsReferenceAddress.UIAssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.HeartIconAddress);
			GameObject icon = _createObject.Instantiate(prefab, parentTransform);

			icon.transform.localPosition = position; 
			
			_heartIcons.Add(icon);
		}

		public void Destroy(GameObject gameObject) => 
			Object.Destroy(gameObject);
	}
}