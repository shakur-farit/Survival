using UI.Services.Factory;
namespace Infrastructure.States.Factory
{
	public interface IStatesFactory
	{
		TState Create<TState>() where TState : IState;
	}
}