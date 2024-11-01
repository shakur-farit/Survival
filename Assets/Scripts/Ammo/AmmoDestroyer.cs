using Ammo.Factory;
using SpecialEffects.Factory;
using UnityEngine;

namespace Ammo
{
	public class AmmoDestroyer : IAmmoDestroyer
	{
		private readonly IAmmoFactory _ammoFactory;
		private readonly IHitSpecialEffectsFactory _specialEffectsFactory;

		public AmmoDestroyer(IAmmoFactory ammoFactory, IHitSpecialEffectsFactory specialEffectsFactory)
		{
			_ammoFactory = ammoFactory;
			_specialEffectsFactory = specialEffectsFactory;
		}

		public void DestroyOnOutOfDetectedRange(GameObject gameObject) => 
			Destroy(gameObject);

		public void DestroyInHit(GameObject gameObject, Vector2 position)
		{
			Destroy(gameObject);

			CreateHitEffect(position);
		}

		private void CreateHitEffect(Vector2 position) => 
			_specialEffectsFactory.Create(position);

		private void Destroy(GameObject gameObject) => 
			_ammoFactory.Destroy(gameObject);
	}
}