using System;
using Cysharp.Threading.Tasks;
using Utility;

namespace Infrastructure.Services.Timer
{
	public class TimerService : ICountDownTimer
	{
		private int _timeLeft;

		public event Action Started;
		public event Action Completed;

		public async UniTask Start(int durationInSeconds)
		{
			Started?.Invoke();

			_timeLeft = durationInSeconds;

			while (_timeLeft > 0)
			{
				await UniTask.Delay(Constants.OneSecond);
				_timeLeft--;
			}

			Completed?.Invoke();
		}

		public int GetTimeLeft() => 
			_timeLeft;
	}
}