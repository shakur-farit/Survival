using Character.States.Aim;
using Character.States.Motion;
using Character.States.StatesMachine.Aim;
using Character.States.StatesMachine.Motion;
using EnemyLogic.States;
using EnemyLogic.States.StateMachine;
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
		private ICharacterMotionStatesRegistrar _characterMotionStatesRegistrar;
		private ICharacterAimStatesRegistrar _characterAimStatesRegistrar;

		[Inject]
		public void Constructor(IGameStatesRegistrar gameStatesRegistrar, IStatesFactory statesFactory,
			IGameStatesSwitcher gameStatesSwitcher, ICharacterMotionStatesRegistrar characterMotionStatesRegistrar,
			ICharacterAimStatesRegistrar characterAimStatesMachine)
		{
			_gameStatesRegistrar = gameStatesRegistrar;
			_gameStatesSwitcher = gameStatesSwitcher;
			_statesFactory = statesFactory;
			_characterMotionStatesRegistrar	= characterMotionStatesRegistrar;
			_characterAimStatesRegistrar = characterAimStatesMachine;
		}

		private void Awake()
		{
			StartStateMachine();

			DontDestroyOnLoad(this);
		}

		private void StartStateMachine()
		{
			RegisterStates();

			_gameStatesSwitcher.SwitchState<WarmUpState>();
		}

		private void RegisterStates()
		{
			RegisterGameStates();
			RegisterCharacterStates();
		}

		private void RegisterGameStates()
		{
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<WarmUpState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LoadStaticDataState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LoadProgressState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LoadSceneState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<MainMenuState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<GameLoopingState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LoadLevelState>());
		}

		private void RegisterCharacterStates()
		{
			_characterMotionStatesRegistrar.RegisterState(_statesFactory.CreateCharacterStates<CharacterIdlingState>());
			_characterMotionStatesRegistrar.RegisterState(_statesFactory.CreateCharacterStates<CharacterMovingState>());

			_characterAimStatesRegistrar.RegisterState(_statesFactory.CreateCharacterStates<CharacterAimUpState>());
			_characterAimStatesRegistrar.RegisterState(_statesFactory.CreateCharacterStates<CharacterAimUpRightState>());
			_characterAimStatesRegistrar.RegisterState(_statesFactory.CreateCharacterStates<CharacterAimUpLeftState>());
			_characterAimStatesRegistrar.RegisterState(_statesFactory.CreateCharacterStates<CharacterAimRightState>());
			_characterAimStatesRegistrar.RegisterState(_statesFactory.CreateCharacterStates<CharacterAimLeftState>());
			_characterAimStatesRegistrar.RegisterState(_statesFactory.CreateCharacterStates<CharacterAimDownState>());
		}
	}
}