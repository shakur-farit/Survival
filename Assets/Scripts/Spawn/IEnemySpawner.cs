using Cysharp.Threading.Tasks;
using StaticData;

namespace Spawn
{
	public interface IEnemySpawner
	{
		UniTask Spawn(LevelStaticData levelStaticData);
		void StopSpawn();
	}
}