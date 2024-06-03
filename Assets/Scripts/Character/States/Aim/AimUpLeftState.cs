using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimUpLeftState : CharacterState
	{
		public AimUpLeftState(ICharacterFactory characterFactory) :
			base(characterFactory)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimUpLeft();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimUpLeft();
	}
}