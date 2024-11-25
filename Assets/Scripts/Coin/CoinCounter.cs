using System;
using Data;
using Infrastructure.Services.PersistentProgress;

namespace Coin
{
	public class CoinCounter : ICoinCounter
	{
		public event Action CoinCountChanged;
		
		private readonly IPersistentProgressService _persistentProgressService;

		public CoinCounter(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		public void AddCoin(int dropValue)
		{
			_persistentProgressService.Progress.CoinData.CurrentCoinCount += dropValue;

			CoinCountChanged?.Invoke();
		}

		public void RemoveCoin(int value)
		{
			ScoreData scoreData = _persistentProgressService.Progress.CoinData;

			scoreData.CurrentCoinCount -= value;

			if (scoreData.CurrentCoinCount < 0)
				scoreData.CurrentCoinCount = 0;

			CoinCountChanged?.Invoke();
		}
	}
}