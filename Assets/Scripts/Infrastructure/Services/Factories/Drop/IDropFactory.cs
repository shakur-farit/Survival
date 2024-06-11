using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Factories.Drop
{
	public interface IDropFactory
	{
		UniTask<GameObject> Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}