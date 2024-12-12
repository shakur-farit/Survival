using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PauseService;
using UnityEngine;
using Utility;

namespace Infrastructure.Services.Timer
{
	public class TimerService : ICountDownTimer
	{
		private int _timeLeft;
		private bool _isRunning;

		public event Action Started;
		public event Action Completed;

		private readonly IPauseService _pauseService;


		public TimerService(IPauseService pauseService) => 
			_pauseService = pauseService;

		public async UniTask Start(int durationInSeconds)
		{
			if (_isRunning)
			{
				Debug.LogWarning("Timer is already running!");
				return;
			}

			Started?.Invoke();

			_timeLeft = durationInSeconds;

			while (_timeLeft > 0)
			{

				while (_pauseService.IsPaused) {
					await UniTask.Yield();}

				await UniTask.Delay(Constants.OneSecond);
				_timeLeft--;
				Debug.Log(_timeLeft);
			}

			Completed?.Invoke();
			_isRunning = false;

			Debug.LogWarning("End");

		}

		public int GetTimeLeft() => 
			_timeLeft;
	}
}