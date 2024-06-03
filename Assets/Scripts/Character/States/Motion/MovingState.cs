using Infrastructure.Services.Factories.Character;

namespace Character.States.Motion
{
	public class MovingState : CharacterState
	{
		public MovingState(ICharacterFactory characterFactory) :
			base(characterFactory)
		{
		}

		protected override void StartAnimation() => 
			CharacterAnimator.StartMoving();

		protected override void StopAnimation() => 
			CharacterAnimator.StopMoving();
	}
}