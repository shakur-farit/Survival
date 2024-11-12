using UnityEngine;

namespace Effects.SpecialEffects.Shot.Factory
{
	public interface IShootSpecialEffectsFactory
	{
		void Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}