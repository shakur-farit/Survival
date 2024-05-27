using Infrastructure.Services.Input;
using Infrastructure.States;
using Infrastructure.Services.Factories.Character;
using UnityEngine;

namespace Character.States.StateMachine
{
	public class MoveState : IState
	{
		private CharacterAnimator _characterAniamtor;
		private readonly ICharacterFactory _characterFactory;

		public MoveState(ICharacterFactory characterFactory)
		{
			_characterFactory = characterFactory;
		}

		public void Enter()
		{
			InitCharacterAnimator();
			Debug.Log(GetType());
			_characterAniamtor.StartMoving();
		}

		public void Exit()
		{
		}

		private void InitCharacterAnimator()
		{
			_characterAniamtor = _characterFactory.Character.GetComponent<CharacterAnimator>();
		}
	}
}