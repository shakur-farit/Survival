using DG.Tweening;
using UnityEngine;
using Utility;

namespace DropLogic
{
	public class DropAnimator : IDropAnimator
	{
		private Vector2 RotateEndValue => new(0f, 360f);

		public void Rotate(Transform transform) =>
			transform.DOLocalRotate(RotateEndValue, Constants.RotateDuration, RotateMode.FastBeyond360)
				.SetLoops(Constants.ValueOfInfinity);

		public void Appear(Transform transform) =>
			transform.DOLocalJump(transform.position, Constants.JumpPower,
				Constants.JumpNumber, Constants.JumDuration).SetEase(Ease.OutBounce);

		public void KillTwin(Transform transform) => 
			DOTween.Kill(transform);
	}
}