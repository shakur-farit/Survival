namespace Enemy.States.StateMachine
{
	public interface IEnemyAimStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IEnemyAnimatorState;
	}
}