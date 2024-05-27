using Character.States.StatesMachine.Motion;
using Events;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Motion
{
	public class IdlingState : MotionState
	{
		public IdlingState(ICharacterFactory characterFactory, ICharacterMotionEvent characterMotionEvent,
			ICharacterMotionStatesSwitcher characterMotionStatesSwitcher) : 
			base(characterFactory, characterMotionEvent, characterMotionStatesSwitcher)
		{
		}

		protected override void SubscribeEvent() => 
			CharacterMotionEvent.CharacterMotionSwitched += EnterInMovingState;

		protected override void UnsubscribeEvent() => 
			CharacterMotionEvent.CharacterMotionSwitched -= EnterInMovingState;

		protected override void StartAnimation() => 
			CharacterAnimator.StartIdling();

		protected override void StopAnimation() => 
			CharacterAnimator.StopIdling();

		private void EnterInMovingState() => 
			CharacterMotionStatesSwitcher.SwitchState<MovingState>();
	}
}