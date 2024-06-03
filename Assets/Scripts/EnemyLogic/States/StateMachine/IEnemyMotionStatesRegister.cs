using Infrastructure.States;

namespace EnemyLogic.States.StateMachine
{
	public interface IEnemyMotionStatesRegister
	{
		void RegisterState<TState>(TState state) where TState : IState;
	}
}