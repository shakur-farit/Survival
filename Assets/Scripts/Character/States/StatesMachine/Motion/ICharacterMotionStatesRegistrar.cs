namespace Character.States.StatesMachine.Motion
{
	public interface ICharacterMotionStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : ICharacterAnimatorState;
	}
}