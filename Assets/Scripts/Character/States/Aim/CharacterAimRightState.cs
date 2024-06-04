namespace Character.States.Aim
{
	public class CharacterAimRightState : CharacterState
	{
		protected override void StartAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StartAimRight();

		protected override void StopAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StopAimRight();
	}
}