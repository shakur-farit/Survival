namespace Character.States.Motion
{
	public class CharacterMovingState : CharacterState
	{
		protected override void StartAnimation(CharacterAnimator characterAnimator) => 
			characterAnimator.StartMoving();

		protected override void StopAnimation(CharacterAnimator characterAnimator) => 
			characterAnimator.StopMoving();
	}
}