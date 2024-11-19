using UnityEngine;

namespace Effects.SoundEffects.Shot
{
	public interface IHealthPickupSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}