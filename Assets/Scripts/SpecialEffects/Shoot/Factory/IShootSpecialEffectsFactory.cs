using UnityEngine;

namespace SpecialEffects.Factory
{
	public interface IShootSpecialEffectsFactory
	{
		void Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}