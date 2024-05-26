using Infrastructure.Services.Factories.States;
using Infrastructure.States;
using Infrastructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class EnterPoint : MonoBehaviour
	{
		private IGameStateRegistrar _gameStatesRegistrar;
		private IGameStateSwitcher _gameStatesSwitcher;
		private IStatesFactory _statesFactory;

		[Inject]
		public void Constructor(IGameStateRegistrar gameStatesRegistrar, IStatesFactory statesFactory,
			IGameStateSwitcher gameStatesSwitcher)
		{
			_gameStatesRegistrar = gameStatesRegistrar;
			_gameStatesSwitcher = gameStatesSwitcher;
			_statesFactory = statesFactory;
		}

		private void Awake()
		{
			StartStateMachine();

			DontDestroyOnLoad(this);
		}

		private void StartStateMachine()
		{
			RegisterGameStates();

			_gameStatesSwitcher.SwitchState<WarmUpState>();
		}

		private void RegisterGameStates()
		{
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<WarmUpState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<LoadStaticDataState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<LoadProgressState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<LoadSceneState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<MainMenuState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<GameLoopingState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<LoadLevelState>());
		}
	}
}