using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Hud.Factory
{
	public class AmmoIconFactory : IAmmoIconFactory
	{
		private readonly List<GameObject> _ammoIcons = new();
		private readonly IObjectsPool _objectsPool;

		public List<GameObject> AmmoIcons => _ammoIcons;

		protected AmmoIconFactory(IObjectsPool objectsPool) => 
			_objectsPool = objectsPool;

		public async UniTask Create(Transform parentTransform, Vector2 position)
		{
			GameObject icon = await _objectsPool.UseObject(PooledObjectType.AmmoIcon, parentTransform);
			icon.transform.localPosition = position;
			_ammoIcons.Add(icon);
		}

		public void Destroy(GameObject gameObject) => 
			_objectsPool.ReturnObject(PooledObjectType.AmmoIcon, gameObject);
	}
}