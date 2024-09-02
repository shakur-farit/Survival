using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Hud.Factory
{
	public class HeartIconFactory : IHeartIconFactory
	{
		private readonly List<GameObject> _heartIcons = new();
		private readonly IObjectsPool _objectsPool;

		public List<GameObject> HeartIcons => _heartIcons;

		protected HeartIconFactory(IObjectsPool objectsPool) => 
			_objectsPool = objectsPool;

		public async UniTask Create(Transform parentTransform, Vector2 position)
		{

			GameObject icon = await _objectsPool.UseObject(PooledObjectType.HeartIcon, parentTransform);
			icon.transform.localPosition = position;
			_heartIcons.Add(icon);
		}

		public void Destroy(GameObject gameObject) => 
			_objectsPool.ReturnObject(PooledObjectType.HeartIcon, gameObject);
	}
}