using System;
using Data;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Score
{
	public class ScoreCounter : IScoreCounter
	{
		public event Action ScoreChanged;
		
		private readonly IPersistentProgressService _persistentProgressService;

		public ScoreCounter(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		public void AddScore(int dropValue)
		{
			_persistentProgressService.Progress.ScoreData.CurrentScore += dropValue;

			ScoreChanged?.Invoke();
		}

		public void RemoveScore(int value)
		{
			ScoreData scoreData = _persistentProgressService.Progress.ScoreData;

			scoreData.CurrentScore -= value;

			if (scoreData.CurrentScore < 0)
				scoreData.CurrentScore = 0;

			ScoreChanged?.Invoke();
		}
	}
}