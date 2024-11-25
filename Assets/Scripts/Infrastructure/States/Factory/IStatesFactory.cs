using Character.States;
using Enemy.States;
using Infrastructure.States.GameStates;
using Infrastructure.States.LevelLoopStates;

namespace Infrastructure.States.Factory
{
	public interface IStatesFactory
	{
		TState CreateGameStates<TState>() where TState : IGameState;
		TState CreateCharacterStates<TState>() where TState : ICharacterAnimatorState;
		TState CreateEnemyStates<TState>() where TState : IEnemyAnimatorState;
		TState CreateLevelLoopStates<TState>() where TState : ILevelLoopState;
	}
}