using UnityEngine;

namespace Effects.SoundEffects.DoorsOpening.Factory
{
	public interface IDoorsOpeningSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}