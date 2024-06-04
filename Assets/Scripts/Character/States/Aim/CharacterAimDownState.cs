namespace Character.States.Aim
{
	public class CharacterAimDownState : CharacterState
	{
		protected override void StartAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StartAimDown();

		protected override void StopAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StopAimDown();
	}
}