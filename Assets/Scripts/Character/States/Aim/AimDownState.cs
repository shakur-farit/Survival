using Character.States.StatesMachine.Aim;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimDownState : AimState
	{
		public AimDownState(ICharacterFactory characterFactory, ICharacterAimStatesSwitcher characterAimStatesSwitcher) :
			base(characterFactory, characterAimStatesSwitcher)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimDown();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimDown();
	}
}