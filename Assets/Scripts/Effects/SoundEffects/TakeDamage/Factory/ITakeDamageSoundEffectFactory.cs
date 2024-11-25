using UnityEngine;

namespace Effects.SoundEffects.TakeDamage.Factory
{
	public interface ITakeDamageSoundEffectFactory
	{
		void Destroy(GameObject gameObject);
		void Create();
	}
}