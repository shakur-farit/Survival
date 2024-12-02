using UnityEngine;

namespace Effects.SoundEffects.Error.Factory
{
	public interface IErrorSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}