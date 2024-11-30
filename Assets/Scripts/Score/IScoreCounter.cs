using System;

namespace Coin
{
	public interface IScoreCounter
	{
		event Action ScoreChanged;
		int Score { get; }
		void AddScore(int scoreAmount);
		void ResetScore();
	}
}