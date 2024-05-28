using Character.States.StatesMachine.Aim;
using Events;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimRightState : AimState
	{
		public AimRightState(ICharacterFactory characterFactory, ICharacterAimEvent characterAimEvent, 
			ICharacterAimStatesSwitcher characterAimStatesSwitcher) : 
			base(characterFactory, characterAimEvent, characterAimStatesSwitcher)
		{
		}

		protected override void SubscribeEvent() =>
			CharacterAimEvent.CharacterAimSwitched += SwitchState;

		protected override void UnsubscribeEvent() =>
			CharacterAimEvent.CharacterAimSwitched -= SwitchState;

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimRight();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimRight();

		private void SwitchState()
		{
			//CharacterAimStatesSwitcher.SwitchState<AimUpState>();
		}
	}
}