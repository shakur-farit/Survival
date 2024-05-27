using Events;
using Infrastructure.States;
using UnityEngine;

namespace Character.States.StateMachine
{
	public class IdleState : IState
	{
		private CharacterAnimator _characterAnimator;
		private readonly ICharacterMoveEvent _characterMoveEvent;
		private readonly ICharacterStatesSwitcher _characterStatesSwitcher;

		public IdleState(ICharacterMoveEvent characterMoveEvent, ICharacterStatesSwitcher characterStatesSwitcher)
		{
			_characterMoveEvent = characterMoveEvent;
			_characterStatesSwitcher = characterStatesSwitcher;
		}

		public void Enter()
		{
			Debug.Log(GetType());
			_characterMoveEvent.CharacterStartedMove += EnterInMoveState;
		}

		public void Exit()
		{
		}

		private void EnterInMoveState() => 
			_characterStatesSwitcher.SwitchState<MoveState>();
	}
}