namespace Character.States.Aim
{
	public class CharacterAimUpState : CharacterState
	{
		protected override void StartAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StartAimUp();

		protected override void StopAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StopAimUp();
	}
}