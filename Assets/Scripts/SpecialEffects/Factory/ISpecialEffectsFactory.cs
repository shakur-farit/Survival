using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SpecialEffects.Factory
{
	public interface ISpecialEffectsFactory
	{
		UniTask<GameObject> CreateSpecialEffect(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}