using UnityEngine;

namespace Effects.SoundEffects.Click
{
	public interface IErrorSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}