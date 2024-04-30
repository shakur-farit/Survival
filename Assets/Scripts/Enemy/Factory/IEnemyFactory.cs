using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemy.Factory
{
	public interface IEnemyFactory
	{
		GameObject Enemy { get; }
		UniTask CreateEnemy(Vector2 position);
	}
}