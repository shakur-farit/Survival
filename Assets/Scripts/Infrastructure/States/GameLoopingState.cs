using UnityEngine;

namespace Infrastructure.States
{
	public class GameLoopingState : IState
	{
		private readonly GameStateMachine _gameStateMachine;

		public GameLoopingState(GameStateMachine gameStateMachine) => 
			_gameStateMachine = gameStateMachine;

		public void Enter() => 
			EnterInLoadLevelState();

		private void EnterInLoadLevelState() => 
			_gameStateMachine.Enter<LoadLevelState>();

		public void Exit()
		{
		}
	}
}