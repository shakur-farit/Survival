using Character.States.StatesMachine.Aim;
using Events;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public abstract class AimState : CharacterState
	{
		protected readonly ICharacterAimStatesSwitcher CharacterAimStatesSwitcher;

		protected AimState(ICharacterFactory characterFactory, ICharacterAimStatesSwitcher characterAimStatesSwitcher) : 
			base(characterFactory) =>
			CharacterAimStatesSwitcher = characterAimStatesSwitcher;
	}
}