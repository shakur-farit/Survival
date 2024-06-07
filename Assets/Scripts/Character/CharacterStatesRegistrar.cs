using Character.States.Aim;
using Character.States.Motion;
using Character.States.StatesMachine.Aim;
using Character.States.StatesMachine.Motion;
using Infrastructure.Services.Factories.States;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterStatesRegistrar : MonoBehaviour
	{
		private ICharacterMotionStatesRegistrar _characterMotionStatesRegistrar;
		private ICharacterAimStatesRegistrar _characterAimStatesRegistrar;
		private IStatesFactory _statesFactory;

		[Inject]
		public void Constructor(ICharacterMotionStatesRegistrar characterMotionStatesRegistrar,
			ICharacterAimStatesRegistrar characterAimStatesMachine, IStatesFactory statesFactory)
		{
			_statesFactory = statesFactory;
			_characterMotionStatesRegistrar = characterMotionStatesRegistrar;
			_characterAimStatesRegistrar = characterAimStatesMachine;
		}

		private void Awake() => 
			RegisterCharacterStates();

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