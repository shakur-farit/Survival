using UnityEngine;

namespace SpecialEffects.Factory
{
	public interface ISpecialEffectsFactory
	{
		GameObject CreateSpecialEffect(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}