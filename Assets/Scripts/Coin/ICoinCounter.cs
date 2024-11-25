using System;

namespace Coin
{
	public interface ICoinCounter
	{
		event Action CoinCountChanged;
		void AddCoin(int dropValue);
		void RemoveCoin(int value);
	}
}