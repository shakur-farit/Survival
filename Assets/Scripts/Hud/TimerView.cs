using System;
using Infrastructure.Services.Timer;
using TMPro;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class TimerView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _timerText;

		private ICountDownTimer _timer;

		[Inject]
		public void Constructor(ICountDownTimer timer) => 
			_timer = timer;

		private void OnEnable()
		{
			_timer.Started += ShowTimerText;
			_timer.Completed += HideTimerText;
		}

		private void OnDisable()
		{
			_timer.Started -= ShowTimerText;
			_timer.Completed -= HideTimerText;
		}

		private void Update() => 
			_timerText.text = _timer.GetTimeLeft().ToString();

		private void ShowTimerText() => 
			_timerText.gameObject.SetActive(true);

		private void HideTimerText() => 
			_timerText.gameObject.SetActive(false);
	}
}