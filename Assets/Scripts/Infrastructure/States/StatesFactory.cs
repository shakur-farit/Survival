using Zenject;

namespace Assets.Scripts.Infrastructure.States
{
	public class StatesFactory
	{
		private IInstantiator _instantiator;

		public StatesFactory(IInstantiator instantiator) =>
			this._instantiator = instantiator;

		public TState Create<TState>() where TState : IState =>
			_instantiator.Instantiate<TState>();
	}
}