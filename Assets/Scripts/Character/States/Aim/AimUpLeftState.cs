using Character.States.StatesMachine.Aim;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimUpLeftState : AimState
	{
		public AimUpLeftState(ICharacterFactory characterFactory, ICharacterAimStatesSwitcher characterAimStatesSwitcher) :
			base(characterFactory, characterAimStatesSwitcher)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimUpLeft();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimUpLeft();
	}
}