using Character.States.StatesMachine.Aim;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimRightState : AimState
	{
		public AimRightState(ICharacterFactory characterFactory, ICharacterAimStatesSwitcher characterAimStatesSwitcher) : 
			base(characterFactory, characterAimStatesSwitcher)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimRight();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimRight();
	}
}