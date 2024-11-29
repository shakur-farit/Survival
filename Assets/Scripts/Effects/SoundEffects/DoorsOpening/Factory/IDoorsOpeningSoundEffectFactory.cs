using UnityEngine;

namespace Effects.SoundEffects.Click
{
	public interface IDoorsOpeningSoundEffectFactory
	{
		void Create();
		void Destroy(GameObject gameObject);
	}
}