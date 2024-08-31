using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Ammo.Factory
{
	public interface IAmmoFactory
	{
		UniTask Create(Vector2 position, Quaternion rotation);
		void Destroy(GameObject gameObject);
	}
}