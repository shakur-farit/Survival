using Infrastructure.States;
using Zenject;

namespace Infrastructure.Services.Factories.States
{
	public class StatesFactory : IStatesFactory
	{
		private IInstantiator _instantiator;

		public StatesFactory(IInstantiator instantiator) =>
			_instantiator = instantiator;

		public TState Create<TState>() where TState : IState =>
			_instantiator.Instantiate<TState>();
	}
}