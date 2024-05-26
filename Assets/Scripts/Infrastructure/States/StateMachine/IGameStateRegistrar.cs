namespace Infrastructure.States.StateMachine
{
	public interface IGameStateRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IState;
	}
}