using UnityEngine;

namespace Effects.SoundEffects.Hit.Factory
{
	public interface IHitSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}