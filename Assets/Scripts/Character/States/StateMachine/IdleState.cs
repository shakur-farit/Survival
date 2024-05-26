using System;
using Infrastructure.Services.Input;
using Infrastructure.States;
using UnityEngine;

namespace Character.States.StateMachine
{
	public class IdleState : IState
	{
		private readonly IAimInputService _aimInputService;

		public IdleState(IAimInputService aimInputService)
		{
			_aimInputService = aimInputService;
		}

		public void Enter()
		{
			float angleDegree = GetAngleDegree();

		}

		private float GetAngleDegree()
		{
			Vector2 aimVector = _aimInputService.AimAxis;

			float angleRadians = Mathf.Atan2(aimVector.y, aimVector.x);
			return angleRadians * Mathf.Rad2Deg;
		}

		public void Exit()
		{
			throw new NotImplementedException();
		}
	}
}