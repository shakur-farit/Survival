using UnityEngine;

namespace Effects.SpecialEffects.Shoot.Factory
{
	public interface IShootSpecialEffectsFactory
	{
		void Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}