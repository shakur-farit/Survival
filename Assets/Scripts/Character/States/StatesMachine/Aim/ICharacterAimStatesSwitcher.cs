namespace Character.States.StatesMachine.Aim
{
	public interface ICharacterAimStatesSwitcher
	{
		void SwitchState<TState>(CharacterAnimator characterAnimator) where TState : ICharacterAnimatorState;
	}
}