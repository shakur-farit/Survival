using Infrastructure.States;
using Infrastructure.States.Factory;
using Infrastructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class EnterPoint : MonoBehaviour
	{
		private GameStateMachine _gameStateMachine;
		private StatesFactory _statesFactory;


		[Inject]
		public void Constructor(GameStateMachine gameStateMachine, StatesFactory statesFactory)
		{
			_gameStateMachine = gameStateMachine;
			_statesFactory = statesFactory;
		}

		private void Awake()
		{
			StartGameStateMachine();

			DontDestroyOnLoad(this);
		}

		private void StartGameStateMachine()
		{
			_gameStateMachine.RegisterState(_statesFactory.Create<WarmUpState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadStaticDataState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadProgressState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadSceneState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<MainMenuState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<GameLoopingState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadLevelState>());

			_gameStateMachine.Enter<WarmUpState>();
		}
	}
}