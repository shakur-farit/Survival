namespace Character.States
{
	public interface ICharacterAnimatorState
	{
		void Enter(CharacterAnimator characterAnimator);
		void Exit(CharacterAnimator characterAnimator);
	}
}