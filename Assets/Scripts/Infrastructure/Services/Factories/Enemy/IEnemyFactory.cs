using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Factories.Enemy
{
	public interface IEnemyFactory
	{
		UniTask Create(Vector2 position);
		void Destroy();
	}
}