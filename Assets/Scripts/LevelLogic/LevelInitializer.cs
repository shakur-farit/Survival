using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;

namespace LevelLogic
{
	public class LevelInitializer : ILevelInitializer
	{
		private const int NextLevelStep = 1;

		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IStaticDataService _staticDataService;

		public LevelInitializer(IPersistentProgressService persistentProgressService, IStaticDataService staticDataService)
		{
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		public void SetupLevelStaticData()
		{
			Level level = (Level)(_persistentProgressService.Progress.LevelData.PreviousLevel + NextLevelStep);

			foreach (LevelStaticData levelStaticData in _staticDataService.LevelsListStaticData.LevelsList)
				if (level == levelStaticData.Level)
				{
					Debug.Log(levelStaticData);
					_persistentProgressService.Progress.LevelData.CurrentLevelStaticData = levelStaticData;
				}
		}
	}
}