namespace Character.States.StatesMachine.Motion
{
	public interface ICharacterMotionStatesSwitcher
	{
		void SwitchState<TState>(CharacterAnimator characterAnimator) where TState : ICharacterAnimatorState;
	}
}