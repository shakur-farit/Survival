using System.Linq;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using StaticData;

namespace LevelLogic
{
	public class EnemiesCounter : IEnemiesCounter
	{
		private readonly ITransientGameDataService _transientGameDataService;

		public EnemiesCounter(ITransientGameDataService transientGameDataService) => 
			_transientGameDataService = transientGameDataService;

		public void SetEnemiesNumberInLevel()
		{
			LevelStaticData currentLevelStaticData = _transientGameDataService.Data.LevelData.CurrentLevelStaticData;

			int enemiesNumberInLevel = currentLevelStaticData.WavesOnLevel
				.SelectMany(wave => wave.EnemiesInWave)
				.Sum(enemyInfo => enemyInfo.Number);

			_transientGameDataService.Data.LevelData.EnemiesNumberInLevele = enemiesNumberInLevel;
		}
	}
}