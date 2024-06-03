using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimUpRightState : CharacterState
	{
		public AimUpRightState(ICharacterFactory characterFactory) :
			base(characterFactory)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimUpRight();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimUpRight();
	}
}