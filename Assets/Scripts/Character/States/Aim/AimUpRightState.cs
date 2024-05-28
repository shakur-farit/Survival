using Character.States.StatesMachine.Aim;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimUpRightState : AimState
	{
		public AimUpRightState(ICharacterFactory characterFactory, ICharacterAimStatesSwitcher characterAimStatesSwitcher) :
			base(characterFactory, characterAimStatesSwitcher)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimUpRight();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimUpRight();
	}
}