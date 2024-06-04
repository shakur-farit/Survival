namespace Character.States.Aim
{
	public class CharacterAimLeftState : CharacterState
	{
		protected override void StartAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StartAimLeft();

		protected override void StopAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StopAimLeft();
	}
}