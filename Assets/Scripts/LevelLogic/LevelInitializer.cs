using System.Collections.Generic;
using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticData;
using Utility;

namespace LevelLogic
{
	public class LevelInitializer : ILevelInitializer
	{
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IStaticDataService _staticDataService;
		private readonly IRandomService _random;

		public LevelInitializer(IPersistentProgressService persistentProgressService, IStaticDataService staticDataService, IRandomService random)
		{
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
			_random = random;
		}

		public void SetupLevelStaticData()
		{
			Level level = (Level)(_persistentProgressService.Progress.LevelData.PreviousLevel + Constants.NextLevelStep);

			foreach (LevelStaticData levelStaticData in _staticDataService.LevelsListStaticData.LevelsList)
				if (level == levelStaticData.Level)
				{
					LevelData levelData = _persistentProgressService.Progress.LevelData;

					levelData.CurrentLevelStaticData = levelStaticData;
					List<RoomData> roomsList = levelData.CurrentLevelStaticData.RoomsDataList;

					int randomIndex = _random.Next(0, roomsList.Count);
					levelData.RoomData = roomsList[randomIndex];
				}
		}
	}
}