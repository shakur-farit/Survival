using Character.States.StatesMachine.Aim;
using Events;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimDownState : AimState
	{
		public AimDownState(ICharacterFactory characterFactory, ICharacterAimEvent characterAimEvent,
			ICharacterAimStatesSwitcher characterAimStatesSwitcher) :
			base(characterFactory, characterAimEvent, characterAimStatesSwitcher)
		{
		}

		protected override void SubscribeEvent() =>
			CharacterAimEvent.CharacterAimSwitched += SwitchState;

		protected override void UnsubscribeEvent() =>
			CharacterAimEvent.CharacterAimSwitched -= SwitchState;

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimDown();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimDown();

		private void SwitchState() =>
			CharacterAimStatesSwitcher.SwitchState<AimUpState>();
	}
}