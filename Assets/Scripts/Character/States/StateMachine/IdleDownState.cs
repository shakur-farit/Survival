using Events;
using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Input;

namespace Character.States.StateMachine
{
	public class IdleDownState : IdleState
	{
		public IdleDownState(ICharacterMoveEvent characterMoveEvent, ICharacterStatesSwitcher characterStatesSwitcher) :
			base(characterMoveEvent, characterStatesSwitcher)
		{
		}
	}
}