namespace Infrastructure.States.StateMachine
{
	public interface IGameStateSwitcher
	{
		void SwitchState<TState>() where TState : IState;
	}
}