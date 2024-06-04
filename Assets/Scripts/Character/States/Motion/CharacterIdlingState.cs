namespace Character.States.Motion
{
	public class CharacterIdlingState : CharacterState
	{
		protected override void StartAnimation(CharacterAnimator characterAnimator) => 
			characterAnimator.StartIdling();

		protected override void StopAnimation(CharacterAnimator characterAnimator) => 
			characterAnimator.StopIdling();
	}
}