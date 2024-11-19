using UnityEngine;

namespace Effects.SoundEffects.Shot
{
	public interface ICoinPickupSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}