using Character.States.StatesMachine.Motion;
using Events;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Motion
{
	public class MovingState : MotionState
	{
		public MovingState(ICharacterFactory characterFactory, ICharacterMotionEvent characterMotionEvent,
			ICharacterMotionStatesSwitcher characterMotionStatesSwitcher) : 
			base(characterFactory, characterMotionEvent, characterMotionStatesSwitcher)
		{
		}

		protected override void SubscribeEvent() => 
			CharacterMotionEvent.CharacterMotionSwitched += EnterInIdleState;

		protected override void UnsubscribeEvent() => 
			CharacterMotionEvent.CharacterMotionSwitched -= EnterInIdleState;

		protected override void StartAnimation() => 
			CharacterAnimator.StartMoving();

		protected override void StopAnimation() => 
			CharacterAnimator.StopMoving();

		private void EnterInIdleState() => 
			CharacterMotionStatesSwitcher.SwitchState<IdlingState>();
	}
}