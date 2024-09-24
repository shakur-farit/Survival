using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using Utility;

namespace LevelLogic
{
	public class LevelInitializer : ILevelInitializer
	{
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IStaticDataService _staticDataService;

		public LevelInitializer(IPersistentProgressService persistentProgressService, IStaticDataService staticDataService)
		{
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		public void SetupLevelStaticData()
		{
			Level level = (Level)(_persistentProgressService.Progress.LevelData.PreviousLevel + Constants.NextLevelStep);

			foreach (LevelStaticData levelStaticData in _staticDataService.LevelsListStaticData.LevelsList)
				if (level == levelStaticData.Level)
					_persistentProgressService.Progress.LevelData.CurrentLevelStaticData = levelStaticData;
		}
	}
}