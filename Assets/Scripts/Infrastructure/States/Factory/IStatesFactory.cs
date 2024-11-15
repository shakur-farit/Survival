using Character.States;
using Enemy.States;
using Infrastructure.States.GameLoopStates;
using Infrastructure.States.GameStates;

namespace Infrastructure.States.Factory
{
	public interface IStatesFactory
	{
		TState CreateGameStates<TState>() where TState : IGameState;
		TState CreateCharacterStates<TState>() where TState : ICharacterAnimatorState;
		TState CreateEnemyStates<TState>() where TState : IEnemyAnimatorState;
		TState CreateGameLoopStates<TState>() where TState : IGameLoopState;
	}
}