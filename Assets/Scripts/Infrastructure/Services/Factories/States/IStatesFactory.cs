using Character.States.StatesMachine.Motion;
using EnemyLogic.States;
using Infrastructure.States;

namespace Infrastructure.Services.Factories.States
{
	public interface IStatesFactory
	{
		TState CreateGameStates<TState>() where TState : IGameState;
		TState CreateCharacterStates<TState>() where TState : ICharacterAnimatorState;
		TState CreateEnemyStates<TState>() where TState : IEnemyAnimatorState;
	}
}