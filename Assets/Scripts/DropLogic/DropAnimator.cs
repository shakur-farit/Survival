using DG.Tweening;
using UnityEngine;
using Utility;

namespace DropLogic
{
	public class DropAnimator : MonoBehaviour
	{
		private Vector2 RotateEndValue => new(0f, 360f);

		private void OnEnable()
		{
			Appear();
			Rotate();
		}

		private void OnDisable() => 
			DOTween.Kill(transform);

		private void Rotate() =>
			transform.DOLocalRotate(RotateEndValue, Constants.RotateDuration, RotateMode.FastBeyond360)
				.SetLoops(Constants.ValueOfInfinity);

		private void Appear() =>
			transform.DOLocalJump(transform.position, Constants.JumpPower,
				Constants.JumpNumber, Constants.JumDuration).SetEase(Ease.OutBounce);
	}
}