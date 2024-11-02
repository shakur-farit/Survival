using UnityEngine;

namespace Effects.SpecialEffects.Hit.Factory
{
	public interface IHitSpecialEffectsFactory
	{
		void Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}