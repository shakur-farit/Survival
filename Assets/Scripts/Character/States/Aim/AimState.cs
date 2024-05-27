using Character.States.StatesMachine.Aim;
using Events;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public abstract class AimState : CharacterState
	{
		protected readonly ICharacterAimEvent CharacterAimEvent;
		protected readonly ICharacterAimStatesSwitcher CharacterAimStatesSwitcher;

		protected AimState(ICharacterFactory characterFactory, ICharacterAimEvent characterAimEvent, 
			ICharacterAimStatesSwitcher characterAimStatesSwitcher) : 
			base(characterFactory)
		{
			CharacterAimEvent = characterAimEvent;
			CharacterAimStatesSwitcher = characterAimStatesSwitcher;
		}
	}
}