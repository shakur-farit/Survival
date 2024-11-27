using UnityEngine;

namespace Effects.SoundEffects.TakeDamage.Factory
{
	public interface IHitSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}