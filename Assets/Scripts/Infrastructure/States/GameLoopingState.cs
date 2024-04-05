using UnityEngine;

namespace Infrastructure.States
{
	public class GameLoopingState : IState
	{
		public void Enter()
		{
			Debug.Log("Enter Game");
		}

		public void Exit()
		{
		}
	}
}