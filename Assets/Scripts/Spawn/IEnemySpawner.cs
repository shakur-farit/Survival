using Cysharp.Threading.Tasks;
using StaticData;

namespace Spawn
{
	public interface IEnemySpawner
	{
		UniTask SpawnEnemies(LevelStaticData levelStaticData);
		void StopSpawn();
	}
}