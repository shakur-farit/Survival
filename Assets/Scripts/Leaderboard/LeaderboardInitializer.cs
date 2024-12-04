using System.Collections.Generic;
using System.Linq;
using Data.Persistent;
using Infrastructure.Services.PersistentProgress;
using Score;

namespace Character
{
	public class LeaderboardInitializer : ILeaderboardInitializer
	{
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IScoreCounter _scoreCounter;

		public LeaderboardInitializer(IPersistentProgressService persistentProgressService, IScoreCounter scoreCounter)
		{
			_persistentProgressService = persistentProgressService;
			_scoreCounter = scoreCounter;
		}

		public void Initialize()
		{
			string name = _persistentProgressService.Progress.CharacterData.Name;
			string score = _scoreCounter.Score.ToString();
			List<LeaderboardItemInfo> list = _persistentProgressService.Progress.LeaderboardData.LeaderboardList;

			LeaderboardItemInfo newItem = new LeaderboardItemInfo()
			{
				Name = name,
				Score = score
			};

			list.Add(newItem);

			_persistentProgressService.Progress.LeaderboardData.LeaderboardList = list
				.OrderByDescending(item => item.Score)
				.ToList();
		}
	}
}