using UnityEngine;

namespace Character.States
{
	public abstract class CharacterState : ICharacterAnimatorState
	{
		public void Enter(CharacterAnimator characterAnimator)
		{
			Debug.Log(GetType());

			StartAnimation(characterAnimator);
		}

		public void Exit(CharacterAnimator characterAnimator) => 
			StopAnimation(characterAnimator);

		protected abstract void StartAnimation(CharacterAnimator characterAnimator);

		protected abstract void StopAnimation(CharacterAnimator characterAnimator);
	}
}