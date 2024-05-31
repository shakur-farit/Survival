using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Factories.Enemy
{
	public interface IEnemyFactory
	{
		UniTask<GameObject> Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}