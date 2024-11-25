using UnityEngine;

namespace Effects.SoundEffects.Drop.Coin.Factory
{
	public interface ICoinPickupSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}