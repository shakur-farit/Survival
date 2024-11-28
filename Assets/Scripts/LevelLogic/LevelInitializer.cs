using System.Collections.Generic;
using Data;
using Data.Transient;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.TransientGameData;
using StaticData;
using Utility;

namespace LevelLogic
{
	public class LevelInitializer : ILevelInitializer
	{
		private readonly ITransientGameDataService _transientGameDataService;
		private readonly IStaticDataService _staticDataService;
		private readonly IRandomService _random;

		public LevelInitializer(ITransientGameDataService transientGameDataService, IStaticDataService staticDataService, IRandomService random)
		{
			_transientGameDataService = transientGameDataService;
			_staticDataService = staticDataService;
			_random = random;
		}

		public void SetupLevelStaticData()
		{
			Level level = (Level)(_transientGameDataService.Data.LevelData.PreviousLevel + Constants.NextLevelStep);

			foreach (LevelStaticData levelStaticData in _staticDataService.LevelsListStaticData.LevelsList)
				if (level == levelStaticData.Level)
				{
					LevelData levelData = _transientGameDataService.Data.LevelData;

					levelData.CurrentLevelStaticData = levelStaticData;
					List<RoomData> roomsList = levelData.CurrentLevelStaticData.RoomsDataList;

					int randomIndex = _random.Next(0, roomsList.Count);
					levelData.RoomData = roomsList[randomIndex];
				}
		}
	}
}