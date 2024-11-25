using UnityEngine;

namespace Effects.SoundEffects.Drop.Health.Factory
{
	public interface IHealthPickupSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}