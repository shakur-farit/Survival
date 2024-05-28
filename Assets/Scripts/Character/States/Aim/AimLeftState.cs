using Character.States.StatesMachine.Aim;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimLeftState : AimState
	{
		public AimLeftState(ICharacterFactory characterFactory, ICharacterAimStatesSwitcher characterAimStatesSwitcher) : 
			base(characterFactory, characterAimStatesSwitcher)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimLeft();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimLeft();
	}
}