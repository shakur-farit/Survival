using System;
using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.Timer
{
	public class TimerService : ICountDownTimer
	{
		private int _timeLeft;

		public async UniTask Start(int durationInSeconds, Action onTick, Action onComplete)
		{
			_timeLeft = durationInSeconds;

			while (_timeLeft > 0)
			{
				await UniTask.Delay(1000);
				_timeLeft--;
				onTick?.Invoke();
			}

			onComplete?.Invoke();
		}

		public int GetTimeLeft() => 
			_timeLeft;
	}
}