using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Factories.Ammo
{
	public interface IDropFactory
	{
		UniTask Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}