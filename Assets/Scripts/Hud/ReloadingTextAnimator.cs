using DG.Tweening;
using TMPro;
using UnityEngine;
using Utility;

namespace Hud
{
	public class ReloadingTextAnimator : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _text;

		private Tween _blinkTween;

		private void OnDisable()
		{
			if(_blinkTween != null)
				_blinkTween.Kill();
		}

		private void Awake() => 
			Blink();

		private void Blink() => 
			_text.DOFade(Constants.EndValue, Constants.TextBlinkDuration)
				.SetLoops(Constants.ValueOfInfinity, LoopType.Yoyo);
	}
}