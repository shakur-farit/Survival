using UnityEngine;

namespace Effects.SoundEffects.Shot.Factory
{
	public interface IShotSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}