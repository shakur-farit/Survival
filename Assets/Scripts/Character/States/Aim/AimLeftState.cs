using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimLeftState : CharacterState
	{
		public AimLeftState(ICharacterFactory characterFactory) :
			base(characterFactory)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimLeft();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimLeft();
	}
}