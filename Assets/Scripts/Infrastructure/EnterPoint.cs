using Infrastructure.Services.Factories.States;
using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class EnterPoint : MonoBehaviour
	{
		private IGameStatesRegistrar _gameStatesRegistrar;
		private IGameStatesSwitcher _gameStatesSwitcher;
		private IStatesFactory _statesFactory;
		
		[Inject]
		public void Constructor(IGameStatesRegistrar gameStatesRegistrar, IStatesFactory statesFactory,
			IGameStatesSwitcher gameStatesSwitcher)
		{
			_gameStatesRegistrar = gameStatesRegistrar;
			_gameStatesSwitcher = gameStatesSwitcher;
			_statesFactory = statesFactory;
		}

		private void Awake()
		{
			StartGameStateMachine();

			DontDestroyOnLoad(this);
		}

		private void StartGameStateMachine()
		{
			RegisterStates();

			_gameStatesSwitcher.SwitchState<WarmUpState>();
		}

		private void RegisterStates() => 
			RegisterGameStates();

		private void RegisterGameStates()
		{
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<WarmUpState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LoadStaticDataState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LoadProgressState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LoadSceneState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<MainMenuState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LoadLevelState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LevelComplete>());
		}
	}
}