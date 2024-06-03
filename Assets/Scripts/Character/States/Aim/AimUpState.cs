using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimUpState : CharacterState
	{
		public AimUpState(ICharacterFactory characterFactory) :
			base(characterFactory)
		{
		}

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimUp();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimUp();
	}
}