using Character.States.StatesMachine.Aim;
using Events;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimLeftState : AimState
	{
		public AimLeftState(ICharacterFactory characterFactory, ICharacterAimEvent characterAimEvent, 
			ICharacterAimStatesSwitcher characterAimStatesSwitcher) : 
			base(characterFactory, characterAimEvent, characterAimStatesSwitcher)
		{
		}

		protected override void SubscribeEvent() =>
			CharacterAimEvent.CharacterAimSwitched += SwitchState;

		protected override void UnsubscribeEvent() =>
			CharacterAimEvent.CharacterAimSwitched -= SwitchState;

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimLeft();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimLeft();

		private void SwitchState()
		{
			//CharacterAimStatesSwitcher.SwitchState<AimUpState>();
		}
	}
}