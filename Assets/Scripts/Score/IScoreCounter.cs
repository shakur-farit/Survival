using System;

namespace Score
{
	public interface IScoreCounter
	{
		//int Score { get; }

		void AddScore(int dropValue);
		void RemoveScore(int dropValue);
		event Action ScoreChanged;
	}
}