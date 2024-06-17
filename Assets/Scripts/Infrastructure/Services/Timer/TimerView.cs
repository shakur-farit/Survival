using TMPro;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Timer
{
	public class TimerView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _timerText;

		private ICountDownTimer _timer;

		[Inject]
		public void Constructor(ICountDownTimer timer) => 
			_timer = timer;

		//private async void Start() => 
		//	await _timer.Start(10, OnTick, null);

		private void Update() => 
			_timerText.text = _timer.GetTimeLeft().ToString();
	}
}