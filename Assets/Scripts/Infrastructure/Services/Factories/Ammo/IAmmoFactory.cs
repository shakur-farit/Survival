using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Factories.Ammo
{
	public interface IAmmoFactory
	{
		UniTask Create(Transform parentTransform);
		void Destroy(GameObject gameObject);
	}
}