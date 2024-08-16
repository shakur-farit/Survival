using System;

namespace Score
{
	public interface IScoreCounter
	{
		event Action ScoreChanged;
		void AddScore(int dropValue);
		void RemoveScore(int value);
	}
}