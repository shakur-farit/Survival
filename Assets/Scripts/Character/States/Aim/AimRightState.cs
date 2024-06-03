using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimRightState : CharacterState
	{
		public AimRightState(ICharacterFactory characterFactory) :
			base(characterFactory)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimRight();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimRight();
	}
}