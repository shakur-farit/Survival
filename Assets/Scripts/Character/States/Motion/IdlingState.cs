using Character.States.StatesMachine.Motion;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Motion
{
	public class IdlingState : MotionState
	{
		public IdlingState(ICharacterFactory characterFactory, ICharacterMotionStatesSwitcher characterMotionStatesSwitcher) : 
			base(characterFactory, characterMotionStatesSwitcher)
		{
		}

		protected override void StartAnimation() => 
			CharacterAnimator.StartIdling();

		protected override void StopAnimation() => 
			CharacterAnimator.StopIdling();
	}
}