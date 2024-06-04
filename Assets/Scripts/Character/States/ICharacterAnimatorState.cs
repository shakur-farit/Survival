using Infrastructure.States;

namespace Character.States.StatesMachine.Motion
{
	public interface ICharacterAnimatorState
	{
		void Enter(CharacterAnimator characterAnimator);
		void Exit(CharacterAnimator characterAnimator);
	}
}