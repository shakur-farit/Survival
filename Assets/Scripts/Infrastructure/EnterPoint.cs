using Character.States.Aim;
using Character.States.Motion;
using Character.States.StatesMachine.Aim;
using Character.States.StatesMachine.Motion;
using Infrastructure.States;
using Infrastructure.States.Factory;
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

			_characterMotionStatesRegistrar = characterMotionStatesRegistrar;
			_characterAimStatesRegistrar = characterAimStatesMachine;
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
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<MainMenuState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LoadLevelState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<LevelCompleteState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<GameLoopState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.CreateGameStates<GameOverState>());
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