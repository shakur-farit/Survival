using Infrastructure.States;

namespace EnemyLogic.States.StateMachine
{
	public interface IEnemyAimStatesRegister
	{
		void RegisterState<TState>(TState state) where TState : IEnemyAnimatorState;
	}
}