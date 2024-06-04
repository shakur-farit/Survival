using Character.States.StatesMachine.Motion;
using EnemyLogic.States;
using Infrastructure.States;
using Zenject;

namespace Infrastructure.Services.Factories.States
{
	public class StatesFactory : IStatesFactory
	{
		private IInstantiator _instantiator;

		public StatesFactory(IInstantiator instantiator) =>
			_instantiator = instantiator;

		public TState CreateGameStates<TState>() where TState : IGameState =>
			_instantiator.Instantiate<TState>();

		public TState CreateCharacterStates<TState>() where TState : ICharacterAnimatorState => 
			_instantiator.Instantiate<TState>();

		public TState CreateEnemyStates<TState>() where TState : IEnemyAnimatorState => 
			_instantiator.Instantiate<TState>();
	}
}