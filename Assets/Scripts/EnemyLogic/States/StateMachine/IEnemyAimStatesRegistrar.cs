using Infrastructure.States;

namespace EnemyLogic.States.StateMachine
{
	public interface IEnemyAimStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IEnemyAnimatorState;
	}
}