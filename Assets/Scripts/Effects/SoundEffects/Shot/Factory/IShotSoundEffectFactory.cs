using UnityEngine;

namespace Effects.SoundEffects.Shoot.Factory
{
	public interface IShotSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}