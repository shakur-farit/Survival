using Infrastructure.Services.Factories.Character;
using Infrastructure.States;
using UnityEngine;

namespace Character.States
{
	public abstract class CharacterState : IState
	{
		protected CharacterAnimator CharacterAnimator;

		private readonly ICharacterFactory _characterFactory;

		protected CharacterState(ICharacterFactory characterFactory) => 
			_characterFactory = characterFactory;

		public void Enter()
		{
			Debug.Log(GetType());
			InitCharacterAnimator();
			StartAnimation();
		}

		public void Exit() => 
			StopAnimation();

		protected abstract void StartAnimation();

		protected abstract void StopAnimation();

		private void InitCharacterAnimator()
		{
			if (_characterFactory.Character.TryGetComponent(out CharacterAnimator animator))
				CharacterAnimator = animator;
		}
	}
}