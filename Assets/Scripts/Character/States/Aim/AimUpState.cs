using Character.States.StatesMachine.Aim;
using Events;
using Infrastructure.Services.Factories.Character;

namespace Character.States.Aim
{
	public class AimUpState : AimState
	{
		public AimUpState(ICharacterFactory characterFactory, ICharacterAimEvent characterAimEvent, 
			ICharacterAimStatesSwitcher characterAimStatesSwitcher) : 
			base(characterFactory, characterAimEvent, characterAimStatesSwitcher)
		{
		}

		protected override void SubscribeEvent() =>
			CharacterAimEvent.CharacterAimSwitched += SwitchState;

		protected override void UnsubscribeEvent() =>
			CharacterAimEvent.CharacterAimSwitched -= SwitchState;

		protected override void StartAnimation() =>
			CharacterAnimator.StartAimUp();

		protected override void StopAnimation() =>
			CharacterAnimator.StopAimUp();

		private void SwitchState() =>
			CharacterAimStatesSwitcher.SwitchState<AimDownState>();
	}
}