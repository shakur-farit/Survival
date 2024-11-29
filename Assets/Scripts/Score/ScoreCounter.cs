using System;
using Infrastructure.Services.PersistentProgress;

namespace Coin
{
	public class ScoreCounter : IScoreCounter
	{
		public event Action ScoreChanged;

		private readonly IPersistentProgressService _persistentProgressService;

		public ScoreCounter(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		public int Score { get; private set; }

		public void AddScore(int scoreAmount)
		{
			Score += scoreAmount;

			if(Score > _persistentProgressService.Progress.ScoreData.BestScore)
				_persistentProgressService.Progress.ScoreData.BestScore = Score;

			ScoreChanged?.Invoke();
		}
	}
}