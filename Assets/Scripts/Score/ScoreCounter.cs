using System;
using Infrastructure.Services.PersistentProgress;

namespace Score
{
	public class ScoreCounter : IScoreCounter
	{
		public event Action ScoreChanged;
		
		private readonly IPersistentProgressService _persistentProgressService;

		public ScoreCounter(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		//public int Score { get; private set; }
		
		public void AddScore(int dropValue)
		{
			_persistentProgressService.Progress.ScoreData.CurrentScore += dropValue;

			ScoreChanged?.Invoke();
		}

		public void RemoveScore(int dropValue)
		{
			int score = _persistentProgressService.Progress.ScoreData.CurrentScore;

			score -= dropValue;

			if(score < 0) 
				score = 0;

			ScoreChanged?.Invoke();
		}
	}
}