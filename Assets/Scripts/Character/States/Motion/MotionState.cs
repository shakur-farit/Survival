using Character.States.StatesMachine.Motion;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Motion
{
	public abstract class MotionState : CharacterState
	{
		protected readonly ICharacterMotionStatesSwitcher CharacterMotionStatesSwitcher;

		protected MotionState(ICharacterFactory characterFactory, ICharacterMotionStatesSwitcher characterMotionStatesSwitcher) : 
			base(characterFactory) =>
			CharacterMotionStatesSwitcher = characterMotionStatesSwitcher;
	}
}