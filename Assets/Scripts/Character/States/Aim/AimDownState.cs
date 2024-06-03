using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimDownState : CharacterState
	{
		public AimDownState(ICharacterFactory characterFactory) :
			base(characterFactory)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimDown();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimDown();
	}
}