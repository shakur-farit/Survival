using UnityEngine;

namespace SpecialEffects.Factory
{
	public interface IHitSpecialEffectsFactory
	{
		void Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}