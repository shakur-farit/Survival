using Infrastructure.Services.Factories.Character;

namespace Character.States.Motion
{
	public class IdlingState : CharacterState
	{
		public IdlingState(ICharacterFactory characterFactory) : 
			base(characterFactory)
		{
		}

		protected override void StartAnimation() => 
			CharacterAnimator.StartIdling();

		protected override void StopAnimation() => 
			CharacterAnimator.StopIdling();
	}
}