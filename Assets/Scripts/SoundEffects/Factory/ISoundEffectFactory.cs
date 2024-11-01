using UnityEngine;

namespace SpecialEffects
{
	public interface ISoundEffectFactory
	{
		GameObject CreateSoundEffect();
		void Destroy(GameObject gameObject);
	}
}