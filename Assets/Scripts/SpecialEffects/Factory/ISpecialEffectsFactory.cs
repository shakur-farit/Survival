using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SpecialEffects.Factory
{
	public interface ISpecialEffectsFactory
	{
		UniTask<GameObject> CreateShootEffect(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}