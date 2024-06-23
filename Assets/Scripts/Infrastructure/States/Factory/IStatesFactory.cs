using Character.States;
using Enemy.States;

namespace Infrastructure.States.Factory
{
	public interface IStatesFactory
	{
		TState CreateGameStates<TState>() where TState : IGameState;
		TState CreateCharacterStates<TState>() where TState : ICharacterAnimatorState;
		TState CreateEnemyStates<TState>() where TState : IEnemyAnimatorState;
	}
}