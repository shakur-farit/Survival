using UnityEngine;

namespace Effects.SoundEffects.Shot
{
	public interface IClickSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}