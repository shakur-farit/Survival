using System.Linq;
using Infrastructure.Services.PersistentProgress;
using StaticData;

namespace LevelLogic
{
	public class EnemiesCounter : IEnemiesCounter
	{
		private readonly IPersistentProgressService _persistentProgressService;

		public EnemiesCounter(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		public void SetEnemiesNumberInLevel()
		{
			LevelStaticData currentLevelStaticData = _persistentProgressService.Progress.LevelData.CurrentLevelStaticData;

			int enemiesNumberInLevel = currentLevelStaticData.WavesOnLevel
				.SelectMany(wave => wave.EnemiesInWave)
				.Sum(enemyInfo => enemyInfo.Number);

			_persistentProgressService.Progress.LevelData.EnemiesNumberInLevele = enemiesNumberInLevel;
		}
	}
}