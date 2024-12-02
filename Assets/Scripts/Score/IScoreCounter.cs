using System;

namespace Score
{
	public interface IScoreCounter
	{
		event Action ScoreChanged;
		int Score { get; }
		void AddScore(int scoreAmount);
		void ResetScore();
	}
}