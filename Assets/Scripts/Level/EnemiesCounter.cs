using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;

namespace StaticData
{
	public class EnemiesCounter : IEnemiesCounter
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IPersistentProgressService _persistentProgressService;

		public EnemiesCounter(IStaticDataService staticDataService, IPersistentProgressService persistentProgressService)
		{
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		public int GetCountEnemies()
		{
			int enemiesNumber = 0;
			int currentLevel = _persistentProgressService.Progress.LevelData.CurrentLevel;
			LevelStaticData currentLevelStaticData = _staticDataService.LevelsListStaticData.LevelsList[currentLevel];

				foreach (WavesOnLevelInfo wavesOnLevel in currentLevelStaticData.WavesOnLevel)
				{
					foreach (EnemiesInWaveInfo enemiesInWaveInfo in wavesOnLevel.EnemiesInWave)
					{
						enemiesNumber += enemiesInWaveInfo.Number;
					}
				}

			return enemiesNumber;
		}
	}
}