using Character.States.StatesMachine.Motion;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Motion
{
	public class MovingState : MotionState
	{
		public MovingState(ICharacterFactory characterFactory, ICharacterMotionStatesSwitcher characterMotionStatesSwitcher) : 
			base(characterFactory, characterMotionStatesSwitcher)
		{
		}

		protected override void StartAnimation() => 
			CharacterAnimator.StartMoving();

		protected override void StopAnimation() => 
			CharacterAnimator.StopMoving();
	}
}