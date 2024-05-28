using Character.States.StatesMachine.Aim;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimUpState : AimState
	{
		public AimUpState(ICharacterFactory characterFactory, ICharacterAimStatesSwitcher characterAimStatesSwitcher) : 
			base(characterFactory, characterAimStatesSwitcher)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimUp();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimUp();
	}
}