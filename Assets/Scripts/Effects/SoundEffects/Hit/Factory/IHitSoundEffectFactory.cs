using UnityEngine;

namespace Effects.SoundEffects.Shot
{
	public interface IHitSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}