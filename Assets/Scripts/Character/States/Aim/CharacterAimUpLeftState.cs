namespace Character.States.Aim
{
	public class CharacterAimUpLeftState : CharacterState
	{
		protected override void StartAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StartAimUpLeft();

		protected override void StopAnimation(CharacterAnimator characterAnimator) =>
			characterAnimator.StopAimUpLeft();
	}
}