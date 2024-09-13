using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Hud.Factory
{
	public class AmmoIconFactory : IAmmoIconFactory
	{
		private readonly List<GameObject> _ammoIcons = new();

		private readonly IPoolFactory _poolFactory;

		public List<GameObject> AmmoIcons => _ammoIcons;

		protected AmmoIconFactory(IPoolFactory poolFactory) => 
			_poolFactory = poolFactory;

		public void Create(Transform parentTransform, Vector2 position)
		{
			GameObject icon = _poolFactory.UseObject(PooledObjectType.AmmoIcon, parentTransform);
			icon.transform.localPosition = position;

			_ammoIcons.Add(icon);
		}

		public void Destroy(GameObject gameObject) => 
			_poolFactory.ReturnObject(PooledObjectType.AmmoIcon, gameObject);
	}
}