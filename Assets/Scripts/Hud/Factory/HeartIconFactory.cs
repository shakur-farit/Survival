using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Hud.Factory
{
	public class HeartIconFactory : IHeartIconFactory
	{
		private readonly List<GameObject> _heartIcons = new();

		private readonly IPoolFactory _poolFactory;

		public List<GameObject> HeartIcons => _heartIcons;

		protected HeartIconFactory(IPoolFactory poolFactory) => 
			_poolFactory = poolFactory;

		public void Create(Transform parentTransform, Vector2 position)
		{
			GameObject icon = _poolFactory.UseObject(PooledObjectType.HeartIcon, parentTransform);
			icon.transform.localPosition = position;

			_heartIcons.Add(icon);
		}

		public void Destroy(GameObject gameObject) => 
			_poolFactory.ReturnObject(PooledObjectType.HeartIcon, gameObject);
	}
}