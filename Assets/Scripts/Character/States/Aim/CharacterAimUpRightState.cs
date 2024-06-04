namespace Character.States.Aim
{
	public class CharacterAimUpRightState : CharacterState
	{
		protected override void StartAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StartAimUpRight();

		protected override void StopAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StopAimUpRight();
	}
}