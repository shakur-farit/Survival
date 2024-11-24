using Ammo.Factory;
using Effects.SoundEffects.Shot;
using Effects.SpecialEffects.Hit.Factory;
using UnityEngine;

namespace Ammo
{
	public class AmmoDestroyer : IAmmoDestroyer
	{
		private readonly IAmmoFactory _ammoFactory;
		private readonly IHitSpecialEffectsFactory _specialEffectsFactory;
		private IHitSoundEffectFactory _hitSoundEffectFactory;

		public AmmoDestroyer(IAmmoFactory ammoFactory, IHitSpecialEffectsFactory specialEffectsFactory,
			IHitSoundEffectFactory hitSoundEffectFactory)
		{
			_ammoFactory = ammoFactory;
			_specialEffectsFactory = specialEffectsFactory;
			_hitSoundEffectFactory = hitSoundEffectFactory;
		}

		public void DestroyOnOutOfDetectedRange(GameObject gameObject) => 
			Destroy(gameObject);

		public void DestroyInHit(GameObject gameObject, Vector2 position)
		{
			Destroy(gameObject);

			CreateHitSpecialEffect(position);
			CreateHitSoundEffect();
		}

		private void CreateHitSpecialEffect(Vector2 position) => 
			_specialEffectsFactory.Create(position);

		private void CreateHitSoundEffect() => 
			_hitSoundEffectFactory.Create();

		private void Destroy(GameObject gameObject) => 
			_ammoFactory.Destroy(gameObject);
	}
}