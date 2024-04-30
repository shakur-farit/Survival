namespace Infrastructure.States.StateMachine
{
	public interface IGameStateMachine
	{
		void Enter<TState>() where TState : IState;
		void RegisterState<TState>(TState state) where TState : IState;
	}
}