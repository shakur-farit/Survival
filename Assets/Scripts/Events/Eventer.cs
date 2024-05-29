using System;

namespace Events
{
	public class Eventer : IGamePlayEvents 
	{
		public event Action GameStarted;

		public void CallGameStartedEvent() => 
			GameStarted?.Invoke();
	}
}