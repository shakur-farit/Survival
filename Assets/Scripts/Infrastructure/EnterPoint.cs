using Character.States.Aim;
using Character.States.Motion;
using Character.States.StatesMachine;
using Character.States.StatesMachine.Aim;
using Character.States.StatesMachine.Motion;
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
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<WarmUpState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<LoadStaticDataState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<LoadProgressState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<LoadSceneState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<MainMenuState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<GameLoopingState>());
			_gameStatesRegistrar.RegisterState(_statesFactory.Create<LoadLevelState>());
		}

		private void RegisterCharacterStates()
		{
			_characterMotionStatesRegistrar.RegisterState(_statesFactory.Create<IdlingState>());
			_characterMotionStatesRegistrar.RegisterState(_statesFactory.Create<MovingState>());

			_characterAimStatesRegistrar.RegisterState(_statesFactory.Create<AimUpState>());
			_characterAimStatesRegistrar.RegisterState(_statesFactory.Create<AimDownState>());
		}
	}
}