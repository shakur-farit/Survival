using UnityEngine;

namespace Effects.SoundEffects.Shot
{
	public interface ITakeDamageSoundEffectFactory
	{
		void Destroy(GameObject gameObject);
		void Create();
	}
}