using Ammo.Factory;
using UnityEngine;

namespace Ammo
{
	public class AmmoDeath : IAmmoDeath
	{
		private readonly IAmmoFactory _ammoFactory;

		public AmmoDeath(IAmmoFactory ammoFactory) => 
			_ammoFactory = ammoFactory;

		public void Die(GameObject gameObject) => 
			_ammoFactory.Destroy(gameObject);
	}
}