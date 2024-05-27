using Character.States.StatesMachine.Motion;
using Events;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Motion
{
	public abstract class MotionState : CharacterState
	{
		protected readonly ICharacterMotionEvent CharacterMotionEvent;
		protected readonly ICharacterMotionStatesSwitcher CharacterMotionStatesSwitcher;

		protected MotionState(ICharacterFactory characterFactory, ICharacterMotionEvent characterMotionEvent, 
			ICharacterMotionStatesSwitcher characterMotionStatesSwitcher) : 
			base(characterFactory)
		{
			CharacterMotionEvent = characterMotionEvent;
			CharacterMotionStatesSwitcher = characterMotionStatesSwitcher;
		}
	}
}