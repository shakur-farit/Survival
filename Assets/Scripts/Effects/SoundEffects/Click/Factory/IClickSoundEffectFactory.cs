using UnityEngine;

namespace Effects.SoundEffects.Click.Factory
{
	public interface IClickSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}