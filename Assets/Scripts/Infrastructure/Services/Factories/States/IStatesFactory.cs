using Infrastructure.States;

namespace Infrastructure.Services.Factories.States
{
	public interface IStatesFactory
	{
		TState Create<TState>() where TState : IState;
	}
}