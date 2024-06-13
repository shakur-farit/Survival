using System;

namespace Score
{
	public class ScoreCounter : IScoreCounter
	{
		public event Action ScoreChanged;

		public int Score { get; private set; }
		
		public void AddScore(int dropValue)
		{
			Score += dropValue;

			ScoreChanged?.Invoke();
		}

		public void RemoveScore(int dropValue)
		{
			Score -= dropValue;

			if(Score < 0) 
				Score = 0;

			ScoreChanged?.Invoke();
		}
	}
}