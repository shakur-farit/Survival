using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Timer
{
	public class TimerView : MonoBehaviour
	{
		private ICountDownTimer _timer;

		[Inject]
		public void Constructor(ICountDownTimer timer)
		{
			_timer = timer;
		}

		private async void Start() => 
			await _timer.Start(10, OnTick, null);

		private void OnTick() => 
			Debug.Log(_timer.GetTimeLeft());
	}
}