using System;

namespace Score
{
	public interface ICoinCounter
	{
		event Action CoinCountChanged;
		void AddCoin(int dropValue);
		void RemoveCoin(int value);
	}
}