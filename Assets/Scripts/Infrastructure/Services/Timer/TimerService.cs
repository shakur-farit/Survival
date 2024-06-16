using System;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Infrastructure.Services.Timer
{
	public class TimerService
	{
		public event Action TimeIsUp;

		private const float Zero = 0f;

		private readonly IStaticDataService _staticDataService;
		private readonly IRandomService _randomService;

		private float _countdownTimeDuration;

		private bool _isCountUpTimerStopped;
		private bool _isCountdownTimerStopped;

		public float CountUpTimeDuration { get; private set; }

		private TimerService(IRandomService randomService, IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;
			_randomService = randomService;
		}

		public void UpdateCountdownTimer()
		{
			if (_isCountdownTimerStopped)
				return;

			if (_countdownTimeDuration < 0)
				return;

			_countdownTimeDuration -= Time.deltaTime;

			if (_countdownTimeDuration < 0)
				TimeIsUp?.Invoke();
		}

		public void StartCountdownTimer() =>
			_isCountdownTimerStopped = false;

		public void StopCountdownTimer()
		{
			_isCountdownTimerStopped = true;
			_countdownTimeDuration = Zero;
		}

		public void ResetCountdownTimer(IRandomService random) =>
			_countdownTimeDuration = random.Next(1f, 5f);

		public void UpdateCountUpTimer()
		{
			if (_isCountUpTimerStopped)
				return;

			CountUpTimeDuration += Time.deltaTime;
		}

		public void StartCountUpTimer()
		{
			CountUpTimeDuration = Zero;
			_isCountUpTimerStopped = false;
		}

		public void StopCountUpTimer() =>
			_isCountUpTimerStopped = true;

		//public void SetCountdownTimeDuration() =>
		//	_countdownTimeDuration = _randomService.Next(_staticDataService.ForTimer.Min, _staticDataService.ForTimer.Max);
	}
}