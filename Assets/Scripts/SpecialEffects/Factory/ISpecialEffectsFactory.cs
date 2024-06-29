using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.FactoryBase
{
	public interface ISpecialEffectsFactory
	{
		UniTask Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}