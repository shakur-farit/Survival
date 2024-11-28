using System;
using Data;
using Data.Transient;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;

namespace Coin
{
	public class CoinCounter : ICoinCounter
	{
		public event Action CoinCountChanged;
		
		private readonly ITransientGameDataService _transientGameDataService;

		public CoinCounter(ITransientGameDataService transientGameDataService) => 
			_transientGameDataService = transientGameDataService;

		public void AddCoin(int dropValue)
		{
			_transientGameDataService.Data.CoinData.CurrentCoinCount += dropValue;

			CoinCountChanged?.Invoke();
		}

		public void RemoveCoin(int value)
		{
			CoinData coinData = _transientGameDataService.Data.CoinData;

			coinData.CurrentCoinCount -= value;

			if (coinData.CurrentCoinCount < 0)
				coinData.CurrentCoinCount = 0;

			CoinCountChanged?.Invoke();
		}
	}
}