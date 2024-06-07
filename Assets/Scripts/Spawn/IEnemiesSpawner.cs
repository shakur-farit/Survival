using Cysharp.Threading.Tasks;
using StaticData;

namespace Spawn
{
	public interface IEnemiesSpawner
	{
		UniTask SpawnEnemies(LevelStaticData levelStaticData);
	}
}