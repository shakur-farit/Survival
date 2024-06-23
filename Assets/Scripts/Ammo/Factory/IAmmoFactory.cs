using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Ammo.Factory
{
	public interface IAmmoFactory
	{
		UniTask Create(Transform parentTransform);
		void Destroy(GameObject gameObject);
	}
}